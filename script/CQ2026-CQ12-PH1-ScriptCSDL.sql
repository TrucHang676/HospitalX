-- ========================================================
-- THÔNG TIN CHUNG
-- ========================================================

-- AN TOÀN VÀ BẢO MẬT DỮ LIỆU TRONG HTTT - ĐỒ ÁN THỰC HÀNH
-- NHÓM 12 - 5 thành viên:
--      1. Hoàng Quốc Việt - 23120189
--      2. Trần Kim Yến - 23120193
--      3. Nguyễn Thị Trúc Hằng - 23120201
--      4. Lê Hoàng Nhật Anh - 23120209
--      5. Lê Lâm Trí Đức - 23120237

-- ==========================================================
-- PHÂN HỆ 1: QUẢN TRỊ NGƯỜI DÙNG VÀ BẢO MẬT (ORACLE)
-- ==========================================================

-- THIẾT LẬP BAN ĐẦU: Chạy với sysdba
SET SERVEROUTPUT ON;
SET SQLBLANKLINES ON;
SET VERIFY OFF;

SET DEFINE ON
ACCEPT SYS_PWD CHAR PROMPT 'Nhap mat khau cua SYS (de ket noi AS SYSDBA): ' HIDE
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF

-- Mở PDB và save giúp PDB luôn mở (Bọc trong PL/SQL để tránh lỗi khi đã ở sẵn trong PDB)
BEGIN
    EXECUTE IMMEDIATE 'ALTER PLUGGABLE DATABASE PDBHOSX OPEN';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/
BEGIN
    EXECUTE IMMEDIATE 'ALTER PLUGGABLE DATABASE PDBHOSX SAVE STATE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

-- 1. Chuyển sang PDB của dự án
BEGIN
    EXECUTE IMMEDIATE 'ALTER SESSION SET CONTAINER = PDBHOSX';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

-- Kiểm tra (phải hiện PDBHOSX)
SHOW CON_NAME;

-- XÓA SẠCH CÁC USER/ROLE CŨ NẾU CÓ ĐỂ TRÁNH XUNG ĐỘT KHI CHẠY LẠI SCRIPT
DECLARE
    PROCEDURE kill_user_sessions(p_username IN VARCHAR2) IS
    BEGIN
        FOR s IN (
            SELECT sid, serial# FROM v$session WHERE username = UPPER(p_username)
        ) LOOP
            BEGIN
                EXECUTE IMMEDIATE 'ALTER SYSTEM KILL SESSION ''' || s.sid || ',' || s.serial# || ''' IMMEDIATE';
            EXCEPTION
                WHEN OTHERS THEN NULL;
            END;
        END LOOP;
    END;

    PROCEDURE drop_user_if_exists(p_username IN VARCHAR2) IS
        v_count NUMBER;
    BEGIN
        kill_user_sessions(p_username);
        SELECT COUNT(*) INTO v_count FROM dba_users WHERE username = UPPER(p_username);
        IF v_count > 0 THEN
            EXECUTE IMMEDIATE 'DROP USER ' || UPPER(p_username) || ' CASCADE';
        END IF;
    END;
    
    PROCEDURE drop_role_if_exists(p_rolename IN VARCHAR2) IS
        v_count NUMBER;
    BEGIN
        SELECT COUNT(*) INTO v_count FROM dba_roles WHERE role = UPPER(p_rolename);
        IF v_count > 0 THEN
            EXECUTE IMMEDIATE 'DROP ROLE ' || UPPER(p_rolename);
        END IF;
    END;
BEGIN
    drop_user_if_exists('ADMINHOS');
    drop_user_if_exists('BS_AN');
    drop_user_if_exists('YT_BINH');
    drop_user_if_exists('TEST_USER_1');
    drop_user_if_exists('TEST_USER_2');
    drop_user_if_exists('TEST_USER_3');
    drop_role_if_exists('ROLE_KETOAN');
END;
/
-- 2. Tạo User quản trị (APP DÙNG ACCOUNT NÀY ĐĂNG NHẬP)
CREATE USER adminHos IDENTIFIED BY 123;

-- 3. Cấp quyền DBA để user này có thể Tạo/Xóa/Gán quyền cho người khác
GRANT DBA TO adminHos;

-- 4. Đảm bảo user này có thể đăng nhập được
GRANT CREATE SESSION TO adminHos;

-- 5. Cấp quyền trực tiếp để vào được các proc vẫn còn quyền

-- Cấp quyền quản trị User/Role trực tiếp (Để chạy YC1)
GRANT CREATE USER, ALTER USER, DROP USER TO adminHos;
GRANT CREATE ROLE TO adminHos;
GRANT DROP ANY ROLE TO adminHos;

-- Cấp quyền thực thi các lệnh bảo mật (Để chạy YC3 & YC4)
-- Quyền cấp bất kỳ hệ thống/role nào cho người khác
GRANT GRANT ANY PRIVILEGE TO adminHos;
GRANT GRANT ANY ROLE TO adminHos;

-- Cấp quyền xem dữ liệu hệ thống trực tiếp (YC2 & YC5)
GRANT SELECT ANY DICTIONARY TO adminHos;

-- Cấp quyền quản lý session (Để không bị lỗi ALTER SESSION bên trong Proc)
GRANT ALTER SESSION TO adminHos;

-- Cấp quyền thao tác trên mọi Table/View để làm Phân hệ 2 sau này
GRANT SELECT ANY TABLE, INSERT ANY TABLE, UPDATE ANY TABLE, DELETE ANY TABLE TO adminHos;

-- Cấp quyền thực thi gói VPD cho adminHos
GRANT EXECUTE ON DBMS_RLS TO adminHos;

-- Quyền tạo View 
GRANT CREATE ANY VIEW TO adminHos;
GRANT DROP ANY VIEW TO adminHos;

-- TỰ ĐỘNG CHUYỂN SANG ADMINHOS
conn adminHos/123@localhost:1521/PDBHOSX
SET SERVEROUTPUT ON;
SET SQLBLANKLINES ON;

-- ==========================================================
-- DEMO DATA - PHÂN HỆ 1: QUẢN TRỊ NGƯỜI DÙNG & BẢO MẬT
-- ==========================================================
-- Vì app có thiết kế thông tin user để tạo và chỉnh sửa thông tin
-- nên bắt buộc cần bảng THONGTIN_NHANVIEN

-- Xóa bảng cũ nếu tồn tại (LUONG trước vì có FK phụ thuộc THONGTIN)
BEGIN EXECUTE IMMEDIATE 'DROP TABLE LUONG_NHANVIEN CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE THONGTIN_NHANVIEN CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

-- 1. TẠO CẤU TRÚC DL (CÁC BẢNG CHÍNH)
-- BẢNG NHÂN VIÊN (bắt buộc, ko có lỗi app). PH2 set dữ liệu chuẩn cho nhân viên.
CREATE TABLE THONGTIN_NHANVIEN (
    USERNAME    VARCHAR2(50)   PRIMARY KEY,
    HOTEN       NVARCHAR2(100),
    GIOITINH    NVARCHAR2(10),
    NGAYSINH    DATE,
    SDT         VARCHAR2(15),
    VAITRO      NVARCHAR2(50),
    DIACHI      NVARCHAR2(200),
    NGAYTAO     TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Bảng lương (Liên kết với bảng nhân viên)
CREATE TABLE LUONG_NHANVIEN (
    USERNAME    VARCHAR2(50)  PRIMARY KEY,
    LUONG_CO_BAN NUMBER(12,2),
    PHU_CAP      NUMBER(12,2),
    THUE_TNCN    NUMBER(12,2),
    LUONG_THUC_LANH NUMBER(12,2),
    THANG_NAM    VARCHAR2(7),
    CONSTRAINT FK_LUONG_NV FOREIGN KEY (USERNAME) REFERENCES THONGTIN_NHANVIEN(USERNAME)
);

-- ----------------------------------------------------------
-- YÊU CẦU 1: CÁC THAO TÁC VỚI USER & ROLE (CRUD)
-- ----------------------------------------------------------
-- 1. CÁC THAO TÁC VỚI USER

-- 1.1 Tạo mới User
create or replace PROCEDURE sp_CreateUser (
    p_username IN VARCHAR2,
    p_password IN VARCHAR2,
    p_hoten IN NVARCHAR2, 
    p_tablespace IN VARCHAR2 DEFAULT 'USERS'
)
AS
    v_sql VARCHAR2(500);
BEGIN
    -- 1. Tao User Oracle voi Tablespace va Quota
    v_sql := 'CREATE USER ' || UPPER(p_username) || 
             ' IDENTIFIED BY "' || p_password || '"' ||
             ' DEFAULT TABLESPACE ' || p_tablespace || 
             ' QUOTA UNLIMITED ON ' || p_tablespace;

    EXECUTE IMMEDIATE v_sql;

    -- 2. Cap quyen dang nhap
    EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO ' || UPPER(p_username);

    -- 3. Luu thong tin vao THONGTIN_NHANVIEN
    INSERT INTO THONGTIN_NHANVIEN (USERNAME, HOTEN) 
    VALUES (UPPER(p_username), p_hoten);

    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE_APPLICATION_ERROR(-20001, 'Loi tao User: ' || SQLERRM);
END;
/

-- 1.2 Xóa User
CREATE OR REPLACE PROCEDURE sp_DropUser (
    p_username IN VARCHAR2
)
AS
    v_sql VARCHAR2(200);
BEGIN
    
    -- Sử dụng CASCADE để xóa toàn bộ các objects do user này tạo ra
    v_sql := 'DROP USER ' || p_username || ' CASCADE';
    EXECUTE IMMEDIATE v_sql;
END;
/

-- 1.3 Sửa/Hiệu chỉnh User (Thay đổi mật khẩu)
CREATE OR REPLACE PROCEDURE sp_ChangeUserPassword (
    p_username IN VARCHAR2,
    p_new_password IN VARCHAR2
)
AS
    v_sql VARCHAR2(200);
BEGIN
    
    v_sql := 'ALTER USER ' || p_username || ' IDENTIFIED BY "' || p_new_password || '"';
    EXECUTE IMMEDIATE v_sql;
END;
/

-- 2. CÁC THAO TÁC VỚI ROLE (VAI TRÒ)

-- 2.1 Tạo mới Role 
CREATE OR REPLACE PROCEDURE sp_CreateRole (
    p_role_name IN VARCHAR2
)
AS
    v_sql VARCHAR2(200);
BEGIN
    
    v_sql := 'CREATE ROLE ' || p_role_name;
    EXECUTE IMMEDIATE v_sql;
END;
/

-- 2.2 Xóa Role
CREATE OR REPLACE PROCEDURE sp_DropRole (
    p_role_name IN VARCHAR2
)
AS
    v_sql VARCHAR2(200);
BEGIN
    
    v_sql := 'DROP ROLE ' || p_role_name;
    EXECUTE IMMEDIATE v_sql;
END;
/

-- ----------------------------------------------------------
-- YÊU CẦU 2: LẤY DANH SÁCH USER VÀ ROLE
-- ----------------------------------------------------------

-- Lấy danh sách user (loại trừ user hệ thống mặc định của Oracle)
CREATE OR REPLACE PROCEDURE USP_LIST_USERS (p_cursor OUT SYS_REFCURSOR) AS
BEGIN
    OPEN p_cursor FOR
        SELECT USERNAME, 
               ACCOUNT_STATUS, 
               DEFAULT_TABLESPACE, 
               TO_CHAR(CREATED, 'DD/MM/YYYY') AS CREATED
        FROM   DBA_USERS
        -- Lọc bỏ các user hệ thống dựa trên dải ID hoặc tên mặc định
        WHERE  USER_ID > 100 -- Thường các user hệ thống có ID thấp
          AND  USERNAME NOT IN ('ADMINHOS', 'PDBADMIN') -- Lọc luôn cả admin nếu muốn
          AND  USERNAME NOT LIKE 'C##%'
          AND  ORACLE_MAINTAINED = 'N' -- Đây là chìa khóa: Chỉ lấy user KHÔNG do Oracle duy trì
        ORDER BY USERNAME;
END;
/

-- Lấy danh sách tất cả các role trong hệ thống
CREATE OR REPLACE PROCEDURE USP_LIST_ROLES (p_cursor OUT SYS_REFCURSOR) AS
BEGIN
    OPEN p_cursor FOR
        SELECT ROLE, 
               AUTHENTICATION_TYPE 
        FROM   DBA_ROLES 
        -- Chỉ lấy các Role KHÔNG do Oracle duy trì mặc định
        WHERE  ORACLE_MAINTAINED = 'N'
        ORDER  BY ROLE;
END;
/

-- ----------------------------------------------------------
-- YÊU CẦU 3: CẤP QUYỀN (GRANT PRIVILEGES)
-- ----------------------------------------------------------
-- Xóa nếu tồn tại
BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE VPD_COL_TRACKING PURGE';
EXCEPTION
    WHEN OTHERS THEN NULL; -- Bỏ qua nếu chưa tồn tại
END;
/

-- Chạy 1 lần duy nhất với quyền DBA
-- PHỤC VỤ CHO SELECT MỨC CỘT
CREATE TABLE VPD_COL_TRACKING (
    SCHEMA_NAME  VARCHAR2(128) NOT NULL,
    TABLE_NAME   VARCHAR2(128) NOT NULL,
    POLICY_NAME  VARCHAR2(128) NOT NULL,
    GRANTEE      VARCHAR2(128) NOT NULL,
    HIDDEN_COLS  VARCHAR2(4000),
    CONSTRAINT PK_VPD_COL PRIMARY KEY (SCHEMA_NAME, TABLE_NAME, POLICY_NAME)
);

-- Bảng tracking View ảo cho SELECT mức cột trên VIEW
-- (Lưu mapping: View gốc <-> View ảo <-> Grantee <-> Cột được cấp)
CREATE TABLE VIEW_COL_TRACKING (
    SCHEMA_NAME   VARCHAR2(128) NOT NULL,
    VIEW_NAME     VARCHAR2(128) NOT NULL,   -- Tên View GỐC
    VIRT_VIEW     VARCHAR2(128) NOT NULL,   -- Tên View ảo tổng hợp (V_...)
    GRANTEE       VARCHAR2(128) NOT NULL,
    GRANTED_COLS  VARCHAR2(4000),           -- Danh sách cột đã được cấp
    CONSTRAINT PK_VIEW_COL PRIMARY KEY (SCHEMA_NAME, VIEW_NAME, GRANTEE)
);

-- Dùng cho VPD để grant select mức cột
CREATE OR REPLACE FUNCTION policy_select_column (
    p_schema IN VARCHAR2,
    p_table  IN VARCHAR2
) RETURN VARCHAR2 AS
    v_current_user VARCHAR2(128) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_count        NUMBER;
BEGIN
    -- 1. Chủ schema (adminHos) → luôn thấy full, không filter gì
    IF UPPER(v_current_user) = UPPER(p_schema) THEN
        RETURN NULL;
    END IF;

    -- 2. Kiểm tra user này có bị giới hạn cột trên bảng này không
    SELECT COUNT(*) INTO v_count
    FROM ADMINHOS.VPD_COL_TRACKING
    WHERE SCHEMA_NAME = UPPER(p_schema)
      AND TABLE_NAME  = UPPER(p_table)
      AND GRANTEE     = UPPER(v_current_user);

    -- 3. Có trong tracking → trả về '1=2' → ẩn cột theo sec_relevant_cols
    IF v_count > 0 THEN
        RETURN '1=2';
    END IF;

    -- 4. Không trong tracking (được cấp SELECT toàn bảng) → không filter
    RETURN NULL;

EXCEPTION WHEN OTHERS THEN
    RETURN NULL;  -- An toàn: nếu lỗi gì thì không ẩn gì cả
END;
/

-- Cấp quyền cho user/role
CREATE OR REPLACE PROCEDURE SP_GRANT_PRIVILEGE (
    p_privilege      IN VARCHAR2,  -- SELECT, INSERT, UPDATE, DELETE, EXECUTE
    p_object_type    IN VARCHAR2,  -- TABLE, VIEW, PROCEDURE, FUNCTION
    p_object_name    IN VARCHAR2,  -- Tên đối tượng cụ thể
    p_columns        IN VARCHAR2 DEFAULT NULL, -- Danh sách cột (nếu có), ví dụ: 'HOTEN, LUONG'
    p_grantee        IN VARCHAR2,  -- Tên User hoặc Role được cấp
    p_grantee_type   IN VARCHAR2,  -- 'USER' hoặc 'ROLE'
    p_with_option    IN VARCHAR2   -- 'YES' hoặc 'NO' (GRANT OPTION)
)
AS
    v_sql           VARCHAR2(2000);
    v_option           VARCHAR2(50)  := '';
    v_obj_type         VARCHAR2(20)  := UPPER(p_object_type);
    v_priv             VARCHAR2(20)  := UPPER(p_privilege);
    v_schema           VARCHAR2(50)  := SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA');
    v_policy_name      VARCHAR2(128);
    v_view_name        VARCHAR2(128);
    v_old_virt_view    VARCHAR2(128);
    v_hidden_cols      VARCHAR2(2000);
    v_allowed_cols     VARCHAR2(2000);
    v_existing_hidden  VARCHAR2(2000);
    v_old_granted_cols VARCHAR2(4000);
    v_count            INT;
BEGIN
    -- 1. KIỂM TRA LOGIC NGHIỆP VỤ (Theo yêu cầu 3c)
    
    IF UPPER(p_grantee_type) NOT IN ('USER', 'ROLE') THEN
    RAISE_APPLICATION_ERROR(-20004, 'p_grantee_type phai la USER hoac ROLE.');
    END IF;
    
    IF v_priv NOT IN ('SELECT', 'INSERT', 'UPDATE', 'DELETE', 'EXECUTE') THEN
    RAISE_APPLICATION_ERROR(-20005, 'Quyen khong hop le: ' || p_privilege);
    END IF;
    
    -- Quyền EXECUTE chỉ dành cho PROC/FUNC
    IF v_obj_type IN ('PROCEDURE', 'FUNCTION') AND v_priv != 'EXECUTE' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Procedure/Function chi co the cap quyen EXECUTE.');
    END IF;

    -- Quyền SELECT/UPDATE/INSERT/DELETE chỉ dành cho TABLE/VIEW
    IF v_obj_type IN ('TABLE', 'VIEW') AND v_priv = 'EXECUTE' THEN
        RAISE_APPLICATION_ERROR(-20002, 'Table/View khong the cap quyen EXECUTE.');
    END IF;

    -- Kiểm tra phân quyền mức cột (Yêu cầu 3c: Quyền INSERT/DELETE không được cấp theo cột)
    IF p_columns IS NOT NULL AND v_priv IN ('INSERT', 'DELETE') THEN
        RAISE_APPLICATION_ERROR(-20003, 'Quyen INSERT/DELETE khong ho tro phan quyen muc cot.');
    END IF;

    -- 2. XỬ LÝ OPTION (Chỉ User mới có WITH GRANT OPTION, Role thì không)
    IF UPPER(p_grantee_type) = 'USER' AND UPPER(p_with_option) = 'YES' THEN
        v_option := ' WITH GRANT OPTION';
    ELSIF UPPER(p_grantee_type) = 'ROLE' AND UPPER(p_with_option) = 'YES' THEN
        DBMS_OUTPUT.PUT_LINE('[WARNING] Oracle khong ho tro WITH GRANT OPTION cho ROLE. Tu dong bo qua.');
    END IF;

    -- 3. XÂY DỰNG CÂU LỆNH SQL ĐỘNG
    -- TRƯỜNG HỢP: SELECT mức cột (Dùng view)
    IF v_priv = 'SELECT' AND p_columns IS NOT NULL THEN

        -- ═══ TABLE → VPD ═══
        IF v_obj_type = 'TABLE' THEN
            v_policy_name := 'VPD_SEL_' || UPPER(p_grantee) || '_' || UPPER(p_object_name);

            -- Grant SELECT toàn bảng nếu chưa có
            BEGIN
                EXECUTE IMMEDIATE 'GRANT SELECT ON ' || v_schema || '.' || UPPER(p_object_name)
                    || ' TO ' || p_grantee || v_option;
            EXCEPTION WHEN OTHERS THEN NULL;
            END;

            -- Lấy hidden cols hiện tại từ TRACKING TABLE (không dùng DBA_POLICIES)
            BEGIN
                SELECT HIDDEN_COLS INTO v_existing_hidden
                FROM VPD_COL_TRACKING
                WHERE SCHEMA_NAME = v_schema
                  AND TABLE_NAME  = UPPER(p_object_name)
                  AND POLICY_NAME = v_policy_name;
            EXCEPTION WHEN NO_DATA_FOUND THEN
                v_existing_hidden := NULL;
            END;

            -- Tính allowed = (cột cũ được phép) UNION (cột mới grant thêm)
            IF v_existing_hidden IS NOT NULL THEN
                -- Có policy cũ: allowed cũ = tất cả cột - hidden cũ, gộp thêm cột mới
                SELECT LISTAGG(COLUMN_NAME, ',') WITHIN GROUP (ORDER BY COLUMN_ID)
                INTO v_allowed_cols
                FROM DBA_TAB_COLUMNS
                WHERE TABLE_NAME = UPPER(p_object_name) AND OWNER = v_schema
                  AND (
                      COLUMN_NAME NOT IN (
                          SELECT TRIM(UPPER(REGEXP_SUBSTR(v_existing_hidden, '[^,]+', 1, LEVEL)))
                          FROM DUAL
                          CONNECT BY REGEXP_SUBSTR(v_existing_hidden, '[^,]+', 1, LEVEL) IS NOT NULL
                      )
                      OR
                      COLUMN_NAME IN (
                          SELECT TRIM(UPPER(REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL)))
                          FROM DUAL
                          CONNECT BY REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL) IS NOT NULL
                      )
                  );
            ELSE
                -- Lần đầu: allowed = p_columns (query để chuẩn hóa thứ tự cột)
                SELECT LISTAGG(COLUMN_NAME, ',') WITHIN GROUP (ORDER BY COLUMN_ID)
                INTO v_allowed_cols
                FROM DBA_TAB_COLUMNS
                WHERE TABLE_NAME = UPPER(p_object_name) AND OWNER = v_schema
                  AND COLUMN_NAME IN (
                      SELECT TRIM(UPPER(REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL)))
                      FROM DUAL
                      CONNECT BY REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL) IS NOT NULL
                  );
            END IF;

            -- Tính hidden = tất cả cột - allowed
            SELECT LISTAGG(COLUMN_NAME, ',') WITHIN GROUP (ORDER BY COLUMN_ID)
            INTO v_hidden_cols
            FROM DBA_TAB_COLUMNS
            WHERE TABLE_NAME = UPPER(p_object_name) AND OWNER = v_schema
              AND COLUMN_NAME NOT IN (
                  SELECT TRIM(UPPER(REGEXP_SUBSTR(v_allowed_cols, '[^,]+', 1, LEVEL)))
                  FROM DUAL
                  CONNECT BY REGEXP_SUBSTR(v_allowed_cols, '[^,]+', 1, LEVEL) IS NOT NULL
              );

            -- Drop policy cũ
            BEGIN
                DBMS_RLS.DROP_POLICY(v_schema, UPPER(p_object_name), v_policy_name);
            EXCEPTION WHEN OTHERS THEN NULL;
            END;

            -- Tạo policy mới nếu còn cột cần ẩn
            IF v_hidden_cols IS NOT NULL THEN
                DBMS_RLS.ADD_POLICY(
                    object_schema         => v_schema,
                    object_name           => UPPER(p_object_name),
                    policy_name           => v_policy_name,
                    function_schema       => v_schema,
                    policy_function       => 'POLICY_SELECT_COLUMN',
                    sec_relevant_cols     => v_hidden_cols,
                    sec_relevant_cols_opt => DBMS_RLS.ALL_ROWS
                );
                DBMS_OUTPUT.PUT_LINE('VPD: An [' || v_hidden_cols || '] | Hien [' || v_allowed_cols || ']');
            ELSE
                DBMS_OUTPUT.PUT_LINE('VPD: Tat ca cot duoc phep, khong can policy.');
            END IF;

            -- Ghi / cập nhật tracking table
            MERGE INTO VPD_COL_TRACKING T
            USING (SELECT v_schema           AS SCHEMA_NAME,
                          UPPER(p_object_name) AS TABLE_NAME,
                          v_policy_name      AS POLICY_NAME,
                          UPPER(p_grantee)   AS GRANTEE,
                          v_hidden_cols      AS HIDDEN_COLS
                   FROM DUAL) S
            ON (T.SCHEMA_NAME = S.SCHEMA_NAME
            AND T.TABLE_NAME  = S.TABLE_NAME
            AND T.POLICY_NAME = S.POLICY_NAME)
            WHEN MATCHED    THEN UPDATE SET T.HIDDEN_COLS = S.HIDDEN_COLS,
                                            T.GRANTEE     = S.GRANTEE
            WHEN NOT MATCHED THEN INSERT (SCHEMA_NAME, TABLE_NAME, POLICY_NAME, GRANTEE, HIDDEN_COLS)
                                  VALUES (S.SCHEMA_NAME, S.TABLE_NAME, S.POLICY_NAME, S.GRANTEE, S.HIDDEN_COLS);
            COMMIT;

        -- ═══ VIEW → View trung gian tái sử dụng (có merge cột cũ + tracking) ═══
        ELSIF v_obj_type = 'VIEW' THEN

            -- Đọc cột cũ từ VIEW_COL_TRACKING nếu Grantee đã có quyền trên View này
            v_old_granted_cols := NULL;
            v_old_virt_view    := NULL;
            BEGIN
                SELECT GRANTED_COLS, VIRT_VIEW
                INTO v_old_granted_cols, v_old_virt_view
                FROM VIEW_COL_TRACKING
                WHERE SCHEMA_NAME = v_schema
                  AND VIEW_NAME   = UPPER(p_object_name)
                  AND GRANTEE     = UPPER(p_grantee);
            EXCEPTION WHEN NO_DATA_FOUND THEN
                NULL;
            END;

            -- Tổng hợp cột: merge cột cũ (nếu có) UNION cột mới, chuẩn hóa theo COLUMN_ID
            SELECT LISTAGG(COLUMN_NAME, ',') WITHIN GROUP (ORDER BY COLUMN_ID)
            INTO v_allowed_cols
            FROM DBA_TAB_COLUMNS
            WHERE TABLE_NAME = UPPER(p_object_name) AND OWNER = v_schema
              AND COLUMN_NAME IN (
                  -- Cột mới yêu cầu
                  SELECT TRIM(UPPER(REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL)))
                  FROM DUAL
                  CONNECT BY REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL) IS NOT NULL
                  UNION
                  -- Cột cũ đã được cấp (nếu tồn tại)
                  SELECT TRIM(UPPER(REGEXP_SUBSTR(v_old_granted_cols, '[^,]+', 1, LEVEL)))
                  FROM DUAL
                  WHERE v_old_granted_cols IS NOT NULL
                  CONNECT BY REGEXP_SUBSTR(v_old_granted_cols, '[^,]+', 1, LEVEL) IS NOT NULL
              );

            -- Tên view tổ hợp (nhất quán nhờ COLUMN_ID ordering)
            v_view_name := SUBSTR('V_' || UPPER(p_object_name) || '_'
                           || REPLACE(v_allowed_cols, ',', '_'), 1, 128);

            -- Tạo view ảo mới nếu chưa tồn tại
            SELECT COUNT(*) INTO v_count
            FROM DBA_VIEWS WHERE VIEW_NAME = v_view_name AND OWNER = v_schema;

            IF v_count = 0 THEN
                EXECUTE IMMEDIATE 'CREATE VIEW ' || v_schema || '.' || v_view_name
                    || ' AS SELECT ' || v_allowed_cols
                    || ' FROM '  || v_schema || '.' || UPPER(p_object_name);
                DBMS_OUTPUT.PUT_LINE('Tao view trung gian: ' || v_view_name);
            ELSE
                DBMS_OUTPUT.PUT_LINE('Tai su dung view trung gian: ' || v_view_name);
            END IF;

            -- Grant SELECT trên view ảo mới
            EXECUTE IMMEDIATE 'GRANT SELECT ON ' || v_schema || '.' || v_view_name
                || ' TO ' || p_grantee || v_option;
            DBMS_OUTPUT.PUT_LINE('Grant SELECT [' || v_view_name || '] -> [' || p_grantee || ']');

            -- Revoke view ảo cũ nếu khác view ảo mới (tránh duplicate access)
            IF v_old_virt_view IS NOT NULL AND v_old_virt_view != v_view_name THEN
                BEGIN
                    EXECUTE IMMEDIATE 'REVOKE SELECT ON ' || v_schema || '.' || v_old_virt_view
                        || ' FROM ' || p_grantee;
                    DBMS_OUTPUT.PUT_LINE('Revoke view trung gian cu: ' || v_old_virt_view);
                EXCEPTION WHEN OTHERS THEN NULL;
                END;
            END IF;

            -- Ghi / cập nhật VIEW_COL_TRACKING
            MERGE INTO VIEW_COL_TRACKING T
            USING (SELECT v_schema             AS SCHEMA_NAME,
                          UPPER(p_object_name) AS VIEW_NAME,
                          v_view_name          AS VIRT_VIEW,
                          UPPER(p_grantee)     AS GRANTEE,
                          v_allowed_cols       AS GRANTED_COLS
                   FROM DUAL) S
            ON (T.SCHEMA_NAME = S.SCHEMA_NAME
            AND T.VIEW_NAME   = S.VIEW_NAME
            AND T.GRANTEE     = S.GRANTEE)
            WHEN MATCHED     THEN UPDATE SET T.VIRT_VIEW    = S.VIRT_VIEW,
                                             T.GRANTED_COLS = S.GRANTED_COLS
            WHEN NOT MATCHED THEN INSERT (SCHEMA_NAME, VIEW_NAME, VIRT_VIEW, GRANTEE, GRANTED_COLS)
                                  VALUES (S.SCHEMA_NAME, S.VIEW_NAME, S.VIRT_VIEW, S.GRANTEE, S.GRANTED_COLS);
            COMMIT;
        END IF;


    -- ── UPDATE mức cột ──
    ELSIF v_priv = 'UPDATE' AND p_columns IS NOT NULL THEN
        v_sql := 'GRANT UPDATE (' || p_columns || ') ON '
              || v_schema || '.' || UPPER(p_object_name)
              || ' TO ' || p_grantee || v_option;
        EXECUTE IMMEDIATE v_sql;
        DBMS_OUTPUT.PUT_LINE('Thanh cong: ' || v_sql);

    -- ── Các quyền còn lại (SELECT all cols, INSERT, DELETE, EXECUTE) ──
    ELSE
        v_sql := 'GRANT ' || v_priv || ' ON '
              || v_schema || '.' || UPPER(p_object_name)
              || ' TO ' || p_grantee || v_option;
        EXECUTE IMMEDIATE v_sql;
        DBMS_OUTPUT.PUT_LINE('Thanh cong: ' || v_sql);
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20099, 'Loi SP_GRANT_PRIVILEGE: ' || SQLERRM);
END;
/


-- Cấp role cho user
CREATE OR REPLACE PROCEDURE SP_GRANT_ROLE_TO_USER (
    p_role_name   IN VARCHAR2,
    p_grantee     IN VARCHAR2,
    p_with_admin  IN VARCHAR2   -- 'YES' hoặc 'NO' (tương đương WITH ADMIN OPTION)
)
AS
    v_sql        VARCHAR2(500);
    v_admin_opt  VARCHAR2(30) := '';
BEGIN
    IF UPPER(p_with_admin) = 'YES' THEN
        v_admin_opt := ' WITH ADMIN OPTION';
    END IF;

    v_sql := 'GRANT ' || p_role_name
          || ' TO ' || p_grantee
          || v_admin_opt;

    EXECUTE IMMEDIATE v_sql;

    DBMS_OUTPUT.PUT_LINE('Da cap role: ' || v_sql);
EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20099, 'Loi SP_GRANT_ROLE_TO_USER: ' || SQLERRM);
END SP_GRANT_ROLE_TO_USER;
/

-- ----------------------------------------------------------
-- YÊU CẦU 4: THU HỒI QUYỀN (REVOKE PRIVILEGES)
-- ----------------------------------------------------------


CREATE OR REPLACE PROCEDURE SP_REVOKE_PRIVILEGE (
    p_type      IN VARCHAR2,          -- TABLE, VIEW, PROCEDURE, FUNCTION, ROLE, SYSTEM
    p_privilege IN VARCHAR2,          -- SELECT, UPDATE, DELETE, INSERT, EXECUTE, tên role
    p_object    IN VARCHAR2 DEFAULT NULL, -- Tên đối tượng (NULL với ROLE/SYSTEM)
    p_grantee   IN VARCHAR2,
    p_columns   IN VARCHAR2 DEFAULT NULL  -- Cột muốn thu hồi lẻ (nếu có)
) AS
    v_schema          VARCHAR2(128) := SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA');
    v_obj_clean       VARCHAR2(128) := UPPER(TRIM(p_object));
    v_policy_name     VARCHAR2(128);
    v_current_view    VARCHAR2(128);
    v_new_view_name   VARCHAR2(128);
    v_existing_hidden VARCHAR2(4000);
    v_revoke_cols     VARCHAR2(4000);
    v_new_hidden      VARCHAR2(4000);
    v_remaining_cols  VARCHAR2(4000);
    v_current_cols    VARCHAR2(4000);
    v_count           INT;
    v_total_cols      INT;
    v_hidden_count    INT;
    v_sql             VARCHAR2(2000);
    v_is_grantable   VARCHAR2(3) := 'NO';
BEGIN
    v_policy_name := 'VPD_SEL_' || UPPER(p_grantee) || '_' || v_obj_clean;

    -- ════════════════════════════════════════════
    -- TABLE → VPD
    -- ════════════════════════════════════════════
    IF UPPER(p_type) = 'TABLE' THEN

        IF UPPER(p_privilege) = 'SELECT' THEN

            IF p_columns IS NOT NULL THEN
                -- ── Revoke lẻ cột: ẩn thêm cột vào VPD ──
                v_revoke_cols := UPPER(REPLACE(p_columns, ' ', ''));

                BEGIN
                    SELECT HIDDEN_COLS INTO v_existing_hidden
                    FROM VPD_COL_TRACKING
                    WHERE SCHEMA_NAME = v_schema
                      AND TABLE_NAME  = v_obj_clean
                      AND POLICY_NAME = v_policy_name;
                EXCEPTION WHEN NO_DATA_FOUND THEN
                    v_existing_hidden := NULL;
                END;

                -- Hidden mới = hidden cũ UNION cột vừa revoke
                SELECT LISTAGG(COLUMN_NAME, ',') WITHIN GROUP (ORDER BY COLUMN_ID)
                INTO v_new_hidden
                FROM DBA_TAB_COLUMNS
                WHERE TABLE_NAME = v_obj_clean AND OWNER = v_schema
                  AND (
                      (v_existing_hidden IS NOT NULL AND COLUMN_NAME IN (
                          SELECT TRIM(UPPER(REGEXP_SUBSTR(v_existing_hidden, '[^,]+', 1, LEVEL)))
                          FROM DUAL
                          CONNECT BY REGEXP_SUBSTR(v_existing_hidden, '[^,]+', 1, LEVEL) IS NOT NULL
                      ))
                      OR
                      COLUMN_NAME IN (
                          SELECT TRIM(UPPER(REGEXP_SUBSTR(v_revoke_cols, '[^,]+', 1, LEVEL)))
                          FROM DUAL
                          CONNECT BY REGEXP_SUBSTR(v_revoke_cols, '[^,]+', 1, LEVEL) IS NOT NULL
                      )
                  );

                -- Đếm: nếu ẩn hết thì revoke luôn SELECT toàn bảng
                SELECT COUNT(*) INTO v_total_cols
                FROM DBA_TAB_COLUMNS WHERE TABLE_NAME = v_obj_clean AND OWNER = v_schema;

                SELECT COUNT(*) INTO v_hidden_count
                FROM (
                    SELECT TRIM(UPPER(REGEXP_SUBSTR(v_new_hidden, '[^,]+', 1, LEVEL))) AS COL
                    FROM DUAL
                    CONNECT BY REGEXP_SUBSTR(v_new_hidden, '[^,]+', 1, LEVEL) IS NOT NULL
                );

                IF v_hidden_count >= v_total_cols THEN
                    -- Ẩn hết → revoke toàn bộ + xóa policy + xóa tracking
                    BEGIN
                        DBMS_RLS.DROP_POLICY(v_schema, v_obj_clean, v_policy_name);
                    EXCEPTION WHEN OTHERS THEN NULL;
                    END;
                    EXECUTE IMMEDIATE 'REVOKE SELECT ON ' || v_schema || '.' || v_obj_clean
                        || ' FROM ' || p_grantee;
                    DELETE FROM VPD_COL_TRACKING
                    WHERE SCHEMA_NAME = v_schema
                      AND TABLE_NAME  = v_obj_clean
                      AND POLICY_NAME = v_policy_name;
                    COMMIT;
                    DBMS_OUTPUT.PUT_LINE('Het cot -> Revoke SELECT toan bang [' || v_obj_clean || ']');
                ELSE
                    -- Còn cột → cập nhật VPD ẩn thêm
                    BEGIN
                        DBMS_RLS.DROP_POLICY(v_schema, v_obj_clean, v_policy_name);
                    EXCEPTION WHEN OTHERS THEN NULL;
                    END;
                    DBMS_RLS.ADD_POLICY(
                        object_schema         => v_schema,
                        object_name           => v_obj_clean,
                        policy_name           => v_policy_name,
                        function_schema       => v_schema,
                        policy_function       => 'POLICY_SELECT_COLUMN',
                        sec_relevant_cols     => v_new_hidden,
                        sec_relevant_cols_opt => DBMS_RLS.ALL_ROWS
                    );
                    -- Cập nhật tracking
                    UPDATE VPD_COL_TRACKING
                    SET HIDDEN_COLS = v_new_hidden
                    WHERE SCHEMA_NAME = v_schema
                      AND TABLE_NAME  = v_obj_clean
                      AND POLICY_NAME = v_policy_name;
                    DBMS_OUTPUT.PUT_LINE('VPD cap nhat: An them [' || v_revoke_cols || ']');
                END IF;

            ELSE
                -- ── Revoke toàn bộ SELECT trên TABLE ──
                BEGIN
                    DBMS_RLS.DROP_POLICY(v_schema, v_obj_clean, v_policy_name);
                EXCEPTION WHEN OTHERS THEN NULL;
                END;
                EXECUTE IMMEDIATE 'REVOKE SELECT ON ' || v_schema || '.' || v_obj_clean
                    || ' FROM ' || p_grantee;
                DELETE FROM VPD_COL_TRACKING
                WHERE SCHEMA_NAME = v_schema
                  AND TABLE_NAME  = v_obj_clean
                  AND POLICY_NAME = v_policy_name;
                COMMIT;
                DBMS_OUTPUT.PUT_LINE('Revoke SELECT toan bo bang [' || v_obj_clean || ']');
            END IF;

        ELSIF UPPER(p_privilege) = 'UPDATE' AND p_columns IS NOT NULL THEN
            -- 1. Kiểm tra xem các cột còn lại có With Grant Option không
            SELECT LISTAGG(COLUMN_NAME, ','), MAX(GRANTABLE)
            INTO v_remaining_cols, v_is_grantable
            FROM DBA_COL_PRIVS 
            WHERE GRANTEE = UPPER(p_grantee) AND TABLE_NAME = UPPER(p_object)
              AND PRIVILEGE = UPPER(p_privilege) AND COLUMN_NAME <> UPPER(p_columns);
    
            -- 2. Revoke sạch
            EXECUTE IMMEDIATE 'REVOKE ' || p_privilege || ' ON ' || p_object || ' FROM ' || p_grantee;
    
            -- 3. Cấp lại kèm logic Grant Option cũ
            IF v_remaining_cols IS NOT NULL THEN
                v_sql := 'GRANT ' || p_privilege || '(' || v_remaining_cols || ') ON ' || p_object || ' TO ' || p_grantee;
                IF v_is_grantable = 'YES' THEN v_sql := v_sql || ' WITH GRANT OPTION'; END IF;
                EXECUTE IMMEDIATE v_sql;
            END IF;

        ELSE
            -- INSERT / DELETE / UPDATE all
            EXECUTE IMMEDIATE 'REVOKE ' || UPPER(p_privilege) || ' ON '
                || v_schema || '.' || v_obj_clean || ' FROM ' || p_grantee;
            DBMS_OUTPUT.PUT_LINE('Revoke ' || p_privilege || ' tren [' || v_obj_clean || ']');
        END IF;

    -- ════════════════════════════════════════════
    -- VIEW → View trung gian
    -- ════════════════════════════════════════════
    ELSIF UPPER(p_type) = 'VIEW' THEN

        IF UPPER(p_privilege) = 'SELECT' AND p_columns IS NOT NULL THEN
            -- ── Revoke lẻ cột trên VIEW ──

            -- Ưu tiên đọc từ VIEW_COL_TRACKING (chính xác hơn dò tên view)
            v_current_view := NULL;
            BEGIN
                SELECT VIRT_VIEW INTO v_current_view
                FROM VIEW_COL_TRACKING
                WHERE SCHEMA_NAME = v_schema
                  AND VIEW_NAME   = v_obj_clean
                  AND GRANTEE     = UPPER(p_grantee);
            EXCEPTION WHEN NO_DATA_FOUND THEN
                -- Fallback: tìm theo pattern tên view cũ (tương thích ngược)
                FOR rec IN (
                    SELECT TABLE_NAME FROM DBA_TAB_PRIVS
                    WHERE OWNER     = v_schema
                      AND GRANTEE   = UPPER(p_grantee)
                      AND PRIVILEGE = 'SELECT'
                      AND TABLE_NAME LIKE 'V_' || v_obj_clean || '_%'
                      AND GRANTOR   = v_schema
                ) LOOP
                    v_current_view := rec.TABLE_NAME;
                    EXIT;
                END LOOP;
            END;

            IF v_current_view IS NULL THEN
                RAISE_APPLICATION_ERROR(-20010,
                    'Grantee ' || p_grantee || ' chua co quyen SELECT tren view ' || v_obj_clean);
            END IF;

            -- Cột còn lại = cột view trung gian - cột bị revoke
            SELECT LISTAGG(COLUMN_NAME, ',') WITHIN GROUP (ORDER BY COLUMN_ID)
            INTO v_remaining_cols
            FROM DBA_TAB_COLUMNS
            WHERE TABLE_NAME = v_current_view AND OWNER = v_schema
              AND COLUMN_NAME NOT IN (
                  SELECT TRIM(UPPER(REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL)))
                  FROM DUAL
                  CONNECT BY REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL) IS NOT NULL
              );

            IF v_remaining_cols IS NULL THEN
                -- Không còn cột → revoke view trung gian + xóa tracking
                EXECUTE IMMEDIATE 'REVOKE SELECT ON ' || v_schema || '.' || v_current_view
                    || ' FROM ' || p_grantee;
                DELETE FROM VIEW_COL_TRACKING
                WHERE SCHEMA_NAME = v_schema
                  AND VIEW_NAME   = v_obj_clean
                  AND GRANTEE     = UPPER(p_grantee);
                COMMIT;
                DBMS_OUTPUT.PUT_LINE('Het cot -> Revoke SELECT tren VIEW [' || v_obj_clean || ']');
            ELSE
                -- Còn cột → tạo view ảo mới trực tiếp (không gọi SP_GRANT để tránh đệ quy tracking)
                v_new_view_name := SUBSTR('V_' || v_obj_clean || '_'
                                   || REPLACE(v_remaining_cols, ',', '_'), 1, 128);

                SELECT COUNT(*) INTO v_count
                FROM DBA_VIEWS WHERE VIEW_NAME = v_new_view_name AND OWNER = v_schema;

                IF v_count = 0 THEN
                    EXECUTE IMMEDIATE 'CREATE VIEW ' || v_schema || '.' || v_new_view_name
                        || ' AS SELECT ' || v_remaining_cols
                        || ' FROM ' || v_schema || '.' || v_obj_clean;
                END IF;
                EXECUTE IMMEDIATE 'GRANT SELECT ON ' || v_schema || '.' || v_new_view_name
                    || ' TO ' || p_grantee;

                -- Revoke view cũ (nếu khác view mới)
                IF v_current_view != v_new_view_name THEN
                    EXECUTE IMMEDIATE 'REVOKE SELECT ON ' || v_schema || '.' || v_current_view
                        || ' FROM ' || p_grantee;
                END IF;

                -- Cập nhật VIEW_COL_TRACKING với cột còn lại và view ảo mới
                UPDATE VIEW_COL_TRACKING
                SET VIRT_VIEW    = v_new_view_name,
                    GRANTED_COLS = v_remaining_cols
                WHERE SCHEMA_NAME = v_schema
                  AND VIEW_NAME   = v_obj_clean
                  AND GRANTEE     = UPPER(p_grantee);
                -- Nếu chưa có dòng (tương thích ngược), insert mới
                IF SQL%ROWCOUNT = 0 THEN
                    INSERT INTO VIEW_COL_TRACKING (SCHEMA_NAME, VIEW_NAME, VIRT_VIEW, GRANTEE, GRANTED_COLS)
                    VALUES (v_schema, v_obj_clean, v_new_view_name, UPPER(p_grantee), v_remaining_cols);
                END IF;
                COMMIT;
                DBMS_OUTPUT.PUT_LINE('Cap nhat view, cot con lai: ' || v_remaining_cols);
            END IF;

        ELSIF UPPER(p_privilege) = 'SELECT' AND p_columns IS NULL THEN
            -- ── Revoke toàn bộ SELECT trên VIEW ──
            -- Revoke trực tiếp trên VIEW gốc (trường hợp grant không giới hạn cột)
            BEGIN
                EXECUTE IMMEDIATE 'REVOKE SELECT ON ' || v_schema || '.' || v_obj_clean
                    || ' FROM ' || p_grantee;
            EXCEPTION WHEN OTHERS THEN NULL;
            END;
            -- Revoke cả các view trung gian (từ tracking hoặc dò theo pattern)
            FOR rec IN (
                SELECT VIRT_VIEW AS TABLE_NAME FROM VIEW_COL_TRACKING
                WHERE SCHEMA_NAME = v_schema
                  AND VIEW_NAME   = v_obj_clean
                  AND GRANTEE     = UPPER(p_grantee)
                UNION
                SELECT TABLE_NAME FROM DBA_TAB_PRIVS
                WHERE OWNER     = v_schema
                  AND GRANTEE   = UPPER(p_grantee)
                  AND PRIVILEGE = 'SELECT'
                  AND TABLE_NAME LIKE 'V_' || v_obj_clean || '_%'
            ) LOOP
                BEGIN
                    EXECUTE IMMEDIATE 'REVOKE SELECT ON ' || v_schema || '.' || rec.TABLE_NAME
                        || ' FROM ' || p_grantee;
                EXCEPTION WHEN OTHERS THEN NULL;
                END;
            END LOOP;
            -- Xóa tracking
            DELETE FROM VIEW_COL_TRACKING
            WHERE SCHEMA_NAME = v_schema
              AND VIEW_NAME   = v_obj_clean
              AND GRANTEE     = UPPER(p_grantee);
            COMMIT;
            DBMS_OUTPUT.PUT_LINE('Revoke SELECT toan bo VIEW [' || v_obj_clean || ']');


        ELSIF UPPER(p_privilege) = 'UPDATE' AND p_columns IS NOT NULL THEN
         -- ── Revoke lẻ cột UPDATE trên VIEW ──
                SELECT LISTAGG(COLUMN_NAME, ','),
                       MAX(GRANTABLE)
                INTO v_remaining_cols, v_is_grantable
                FROM DBA_COL_PRIVS
                WHERE GRANTEE    = UPPER(p_grantee)
                  AND OWNER      = v_schema
                  AND TABLE_NAME = v_obj_clean
                  AND PRIVILEGE  = 'UPDATE'
                  AND COLUMN_NAME NOT IN (
                      SELECT TRIM(UPPER(REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL)))
                      FROM DUAL
                      CONNECT BY REGEXP_SUBSTR(UPPER(REPLACE(p_columns,' ','')), '[^,]+', 1, LEVEL) IS NOT NULL
                  );
        
                EXECUTE IMMEDIATE 'REVOKE UPDATE ON ' || v_schema || '.' || v_obj_clean
                    || ' FROM ' || p_grantee;
        
                IF v_remaining_cols IS NOT NULL THEN
                    v_sql := 'GRANT UPDATE (' || v_remaining_cols || ') ON '
                          || v_schema || '.' || v_obj_clean
                          || ' TO ' || p_grantee;
                    IF v_is_grantable = 'YES' THEN
                        v_sql := v_sql || ' WITH GRANT OPTION';
                    END IF;
                    EXECUTE IMMEDIATE v_sql;
                    DBMS_OUTPUT.PUT_LINE('Revoke cot [' || p_columns || '], grant lai ['
                        || v_remaining_cols || '] tren VIEW [' || v_obj_clean || ']');
                ELSE
                    DBMS_OUTPUT.PUT_LINE('Het cot UPDATE -> Revoke toan bo tren VIEW ['
                        || v_obj_clean || ']');
                END IF;
        ELSE
            EXECUTE IMMEDIATE 'REVOKE ' || UPPER(p_privilege) || ' ON '
                || v_schema || '.' || v_obj_clean || ' FROM ' || p_grantee;
        END IF;

    -- ════════════════════════════════════════════
    -- PROCEDURE / FUNCTION
    -- ════════════════════════════════════════════
    ELSIF UPPER(p_type) IN ('PROCEDURE', 'FUNCTION') THEN
        EXECUTE IMMEDIATE 'REVOKE EXECUTE ON ' || v_schema || '.' || v_obj_clean
            || ' FROM ' || p_grantee;
        DBMS_OUTPUT.PUT_LINE('Revoke EXECUTE tren [' || v_obj_clean || ']');

    -- ════════════════════════════════════════════
    -- ROLE / SYSTEM PRIVILEGE
    -- ════════════════════════════════════════════
    ELSE
        EXECUTE IMMEDIATE 'REVOKE ' || UPPER(TRIM(p_privilege))
            || ' FROM ' || UPPER(TRIM(p_grantee));
        DBMS_OUTPUT.PUT_LINE('Revoke ' || p_privilege || ' tu [' || p_grantee || ']');
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20099, 'Loi SP_REVOKE_PRIVILEGE: ' || SQLERRM);
END;
/


-- ----------------------------------------------------------
-- YÊU CẦU 5: KIỂM TRA QUYỀN CỦA USER/ROLE
-- ----------------------------------------------------------

-- Procedure xem quyền trên object: xem user/role có quyền gì trên table, view, procedure, function
CREATE OR REPLACE PROCEDURE USP_GET_OBJ_PRIVS (
    p_grantee IN VARCHAR2,
    p_result  OUT SYS_REFCURSOR
)
AS
    v_schema VARCHAR2(128) := SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA');
BEGIN
    OPEN p_result FOR
        -- A. CÁC QUYỀN BẢNG KHÔNG BỊ VPD (INSERT, DELETE, UPDATE ALL, SELECT ALL)
        --    Lọc bỏ SELECT trên View ảo (V_...) vì sẽ được xử lý ở nhánh D
        SELECT 
            tp.TABLE_NAME AS OBJECT_NAME,
            tp.TYPE,
            tp.PRIVILEGE,
            'ALL COLUMN' AS COLUMN_NAME,
            tp.GRANTABLE AS GRANT_OPTION,
            tp.GRANTOR
        FROM DBA_TAB_PRIVS tp
        WHERE tp.GRANTEE = UPPER(p_grantee) AND tp.OWNER = v_schema
          AND (tp.PRIVILEGE <> 'SELECT' OR NOT EXISTS (
              -- Nếu bảng này KHÔNG có trong tracking VPD của User này thì hiện ALL COLUMN
              SELECT 1 FROM VPD_COL_TRACKING vt 
              WHERE vt.GRANTEE = tp.GRANTEE AND vt.TABLE_NAME = tp.TABLE_NAME
          ))
          -- Loại trừ các View ảo tổng hợp (sẽ hiển thị qua View gốc ở nhánh D)
          AND NOT EXISTS (
              SELECT 1 FROM VIEW_COL_TRACKING vc
              WHERE vc.VIRT_VIEW = tp.TABLE_NAME AND vc.GRANTEE = tp.GRANTEE
          )

        UNION ALL

        -- B. QUYỀN SELECT BỊ GIỚI HẠN BỞI VPD (TÁCH THÀNH TỪNG DÒNG CỘT)
        SELECT 
            tp.TABLE_NAME AS OBJECT_NAME,
            tp.TYPE,
            tp.PRIVILEGE,
            c.COLUMN_NAME, -- Tách ra từng dòng ở đây nè Yến!
            tp.GRANTABLE AS GRANT_OPTION,
            tp.GRANTOR
        FROM DBA_TAB_PRIVS tp
        JOIN VPD_COL_TRACKING vt ON tp.GRANTEE = vt.GRANTEE AND tp.TABLE_NAME = vt.TABLE_NAME
        JOIN DBA_TAB_COLUMNS c ON vt.SCHEMA_NAME = c.OWNER AND vt.TABLE_NAME = c.TABLE_NAME
        WHERE tp.GRANTEE = UPPER(p_grantee) AND tp.OWNER = v_schema AND tp.PRIVILEGE = 'SELECT'
          -- Chỉ lấy những cột KHÔNG nằm trong danh sách Hidden (tức là cột được phép)
          AND c.COLUMN_NAME NOT IN (
              SELECT TRIM(UPPER(REGEXP_SUBSTR(vt.HIDDEN_COLS, '[^,]+', 1, LEVEL)))
              FROM DUAL CONNECT BY REGEXP_SUBSTR(vt.HIDDEN_COLS, '[^,]+', 1, LEVEL) IS NOT NULL
          )

        UNION ALL

        -- C. QUYỀN MỨC CỘT CÓ SẴN (VÍ DỤ UPDATE TRÊN CỘT - GIỮ NGUYÊN)
        SELECT 
            cp.TABLE_NAME AS OBJECT_NAME,
            (SELECT OBJECT_TYPE FROM DBA_OBJECTS 
             WHERE OBJECT_NAME = cp.TABLE_NAME AND OWNER = cp.OWNER 
               AND OBJECT_TYPE IN ('TABLE', 'VIEW') AND ROWNUM = 1) AS TYPE, 
            cp.PRIVILEGE,
            cp.COLUMN_NAME,
            cp.GRANTABLE AS GRANT_OPTION,
            cp.GRANTOR
        FROM DBA_COL_PRIVS cp
        WHERE UPPER(cp.GRANTEE) = UPPER(p_grantee)
          AND cp.OWNER = v_schema

        UNION ALL

        -- D. QUYỀN SELECT MỨC CỘT TRÊN VIEW (truy ngược từ VIEW_COL_TRACKING)
        --    Hiển thị tên View GỐC + từng cột riêng 1 dòng (thay vì tên View ảo)
        SELECT
            vc.VIEW_NAME         AS OBJECT_NAME,  -- Tên View GỐC (không phải View ảo)
            'VIEW'               AS TYPE,
            'SELECT'             AS PRIVILEGE,
            -- Tách GRANTED_COLS thành từng dòng dùng CONNECT BY (an toàn trong ngữ cảnh subquery)
            TRIM(UPPER(
                REGEXP_SUBSTR(vc.GRANTED_COLS, '[^,]+', 1, lvl.LVL)
            ))                   AS COLUMN_NAME,
            tp.GRANTABLE         AS GRANT_OPTION,
            tp.GRANTOR
        FROM VIEW_COL_TRACKING vc
        JOIN DBA_TAB_PRIVS tp
            ON  tp.GRANTEE    = vc.GRANTEE
            AND tp.TABLE_NAME = vc.VIRT_VIEW
            AND tp.PRIVILEGE  = 'SELECT'
            AND tp.OWNER      = v_schema
        JOIN (
            SELECT LEVEL AS LVL FROM DUAL
            CONNECT BY LEVEL <= 50   -- Giới hạn tối đa 50 cột / view
        ) lvl
            ON REGEXP_SUBSTR(vc.GRANTED_COLS, '[^,]+', 1, lvl.LVL) IS NOT NULL
        WHERE vc.SCHEMA_NAME = v_schema
          AND vc.GRANTEE     = UPPER(p_grantee)

        ORDER BY OBJECT_NAME, PRIVILEGE, COLUMN_NAME;
END;
/

-- ----------------------------------------------------------
-- CÁC STORED/FUNC BỔ SUNG ĐỂ HOÀN THIỆN CHỨC NĂNG APP
-- ----------------------------------------------------------

-- Proc liệt kê danh sách user 
create or replace PROCEDURE USP_LIST_ROLE_MEMBERS (
    p_role_name IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT DISTINCT 
               GRANTEE
        FROM   DBA_ROLE_PRIVS
        WHERE  GRANTED_ROLE = UPPER(p_role_name)
          AND  GRANTEE NOT LIKE 'C##%'
          AND  GRANTEE != 'ADMINHOS'
          AND  GRANTEE IN (SELECT USERNAME FROM DBA_USERS WHERE ORACLE_MAINTAINED = 'N')
        ORDER  BY GRANTEE;
EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20020, 'Loi lay danh sach members: ' || SQLERRM);
END;
/

-- Procedure xem role đã được cấp cho 1 user hoặc role
CREATE OR REPLACE PROCEDURE USP_GET_ROLE_PRIVS (
    p_grantee IN VARCHAR2,
    p_result  OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_result FOR
        SELECT GRANTEE,
               GRANTED_ROLE,
               ADMIN_OPTION,
               DEFAULT_ROLE,
               DELEGATE_OPTION,
               COMMON,
               INHERITED
        FROM DBA_ROLE_PRIVS
        WHERE UPPER(GRANTEE) = UPPER(p_grantee)
        ORDER BY GRANTED_ROLE;
END;
/

-- Procedure Khóa tài khoản
CREATE OR REPLACE PROCEDURE sp_LockUser (
    p_username IN VARCHAR2
)
AS
    v_sql VARCHAR2(200);
BEGIN
    -- Lệnh SQL động để khóa account
    v_sql := 'ALTER USER ' || p_username || ' ACCOUNT LOCK';
    
    EXECUTE IMMEDIATE v_sql;
    
    DBMS_OUTPUT.PUT_LINE('User ' || p_username || ' has been LOCKED.');
EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20010, 'Lỗi khi khóa User: ' || SQLERRM);
END;
/

-- Procedure Mở khóa tài khoản
CREATE OR REPLACE PROCEDURE sp_UnlockUser (
    p_username IN VARCHAR2
)
AS
    v_sql VARCHAR2(200);
BEGIN
    -- Lệnh SQL động để mở khóa account
    v_sql := 'ALTER USER ' || p_username || ' ACCOUNT UNLOCK';
    
    EXECUTE IMMEDIATE v_sql;
    
    DBMS_OUTPUT.PUT_LINE('User ' || p_username || ' has been UNLOCKED.');
EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20011, 'Lỗi khi mở khóa User: ' || SQLERRM);
END;
/

-- Load 4 thuộc tính thống kê lên dashboard app
create or replace PROCEDURE USP_DASHBOARD_STATS (
    p_cursor OUT SYS_REFCURSOR
)
AS
    v_user_count NUMBER;
BEGIN
    SELECT NVL(SUM(cnt), 0) INTO v_user_count FROM (
        SELECT COUNT(DISTINCT 
            CASE 
                WHEN du.ORACLE_MAINTAINED = 'N' AND du.USERNAME != 'ADMINHOS' AND du.USERNAME != 'C##ADMIN'
                THEN rp.GRANTEE 
                ELSE NULL 
            END
        ) AS cnt
        FROM DBA_ROLES dr
        LEFT JOIN DBA_ROLE_PRIVS rp ON dr.ROLE = rp.GRANTED_ROLE
        LEFT JOIN DBA_USERS du ON rp.GRANTEE = du.USERNAME
        WHERE dr.ORACLE_MAINTAINED = 'N'
        GROUP BY dr.ROLE
    );

    OPEN p_cursor FOR
        SELECT 
            -- 1. Dem user
            v_user_count AS USER_COUNT,

            -- 2. Dem role
            (SELECT COUNT(*) FROM DBA_ROLES WHERE ORACLE_MAINTAINED = 'N') AS ROLE_COUNT,

            -- 3. Đếm quyền 
            (SELECT COUNT(*) FROM (
                -- 1. Quyền mức Bảng (Table-level)
                SELECT tp.GRANTEE, tp.TABLE_NAME, tp.PRIVILEGE 
                FROM DBA_TAB_PRIVS tp
                JOIN DBA_USERS u ON tp.OWNER = u.USERNAME
                WHERE u.ORACLE_MAINTAINED = 'N' -- Chỉ tính đối tượng do mình tạo
                  AND tp.GRANTEE != 'ADMINHOS'  -- Loại bỏ ông Admin
                  AND tp.GRANTEE NOT IN (SELECT USERNAME FROM DBA_USERS WHERE ORACLE_MAINTAINED = 'Y') -- Loại bỏ user hệ thống nhận quyền
            
                UNION ALL
            
                -- 2. Quyền mức Cột (Column-level)
                SELECT cp.GRANTEE, cp.TABLE_NAME || '.' || cp.COLUMN_NAME, cp.PRIVILEGE
                FROM DBA_COL_PRIVS cp
                JOIN DBA_USERS u ON cp.OWNER = u.USERNAME
                WHERE u.ORACLE_MAINTAINED = 'N'
                  AND cp.GRANTEE != 'ADMINHOS'
                  AND cp.GRANTEE NOT IN (SELECT USERNAME FROM DBA_USERS WHERE ORACLE_MAINTAINED = 'Y')
            )) AS PRIVILEGE_COUNT,

            -- 4. Dem Objects (Table, View, Proc, Func cua User)
            (SELECT COUNT(*) FROM DBA_OBJECTS 
             WHERE OBJECT_TYPE IN ('TABLE','VIEW','PROCEDURE','FUNCTION')
             AND ORACLE_MAINTAINED = 'N') AS OBJECT_COUNT
        FROM DUAL;
EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20001, 'Loi lay dashboard stats: ' || SQLERRM);
END;
/

-- Lấy các role của db kèm số lượng user của role đó
CREATE OR REPLACE PROCEDURE USP_DASHBOARD_ROLE_DISTRIBUTION (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT 
            dr.ROLE AS ROLE_NAME,
            COUNT(DISTINCT 
                CASE 
                    WHEN du.ORACLE_MAINTAINED = 'N' AND du.USERNAME <> 'ADMINHOS'
                    THEN rp.GRANTEE 
                    ELSE NULL 
                END
            ) AS USER_COUNT
        FROM 
            DBA_ROLES dr
        LEFT JOIN 
            DBA_ROLE_PRIVS rp ON dr.ROLE = rp.GRANTED_ROLE
        LEFT JOIN 
            DBA_USERS du ON rp.GRANTEE = du.USERNAME
        WHERE 
            dr.ORACLE_MAINTAINED = 'N'
        GROUP BY 
            dr.ROLE
        ORDER BY 
            USER_COUNT DESC, dr.ROLE;
EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20003, 'Loi lay phan bo role: ' || SQLERRM);
END USP_DASHBOARD_ROLE_DISTRIBUTION;
/

-- Lấy các obj đang có — đếm cả quyền mức bảng (DBA_TAB_PRIVS) + mức cột (DBA_COL_PRIVS)
create or replace PROCEDURE USP_DASHBOARD_OBJECTS (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT 
            o.OBJECT_NAME,
            o.OBJECT_TYPE,
            (SELECT COUNT(*) FROM DBA_TAB_PRIVS p 
             WHERE p.TABLE_NAME = o.OBJECT_NAME AND p.OWNER = o.OWNER)
            +
            (SELECT COUNT(*) FROM DBA_COL_PRIVS p 
             WHERE p.TABLE_NAME = o.OBJECT_NAME AND p.OWNER = o.OWNER)
            AS PRIVILEGE_COUNT
        FROM 
            DBA_OBJECTS o
        WHERE 
            o.OBJECT_TYPE IN ('TABLE','VIEW','PROCEDURE','FUNCTION')
            AND o.ORACLE_MAINTAINED = 'N' -- Chỉ lấy object do user tạo
        ORDER BY 
            o.OBJECT_TYPE, o.OBJECT_NAME;
EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20002, 'L?i l?y danh s?ch objects: ' || SQLERRM);
END;
/

-- Lấy danh sách tablespace sẵn có
CREATE OR REPLACE PROCEDURE USP_GET_TABLESPACES(
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_cursor FOR
    SELECT TABLESPACE_NAME 
    FROM DBA_TABLESPACES
    WHERE STATUS = 'ONLINE'
    ORDER BY TABLESPACE_NAME;
END USP_GET_TABLESPACES;
/

-- Lấy role của 1 user cụ thể
CREATE OR REPLACE PROCEDURE USP_GET_USER_ROLE(
    p_username IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_cursor FOR
    SELECT GRANTED_ROLE
    FROM DBA_ROLE_PRIVS
    WHERE GRANTEE = UPPER(p_username);
END USP_GET_USER_ROLE;
/

-- Lấy dữ liệu từ bảng thông tin nhân viên (user) để tải lên app
CREATE OR REPLACE PROCEDURE USP_GET_USER_INFO (
    p_username IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
) 
AS 
BEGIN
    OPEN p_cursor FOR
    SELECT 
        HOTEN, 
        GIOITINH, 
        SDT, 
        TO_CHAR(NGAYSINH, 'DD/MM/YYYY') AS NGAYSINH, -- Định dạng ngày để đổ vào TextBox
        DIACHI, 
        VAITRO
    FROM THONGTIN_NHANVIEN
    WHERE USERNAME = p_username; -- Giả sử cột khóa ngoại/tên đăng nhập là USERNAME
END;
/

-- Cập nhật thông tin nhân viên (phục vụ demo Ph1)
create or replace PROCEDURE sp_UpdateUserInfo (
    p_username IN VARCHAR2,
    p_hoten IN NVARCHAR2,
    p_gioitinh IN NVARCHAR2,
    p_ngaysinh IN VARCHAR2,
    p_sdt IN VARCHAR2,
    p_diachi IN NVARCHAR2,
    p_vaitro IN NVARCHAR2
)
AS
BEGIN
    UPDATE THONGTIN_NHANVIEN
    SET 
        HOTEN = p_hoten,
        GIOITINH = p_gioitinh,
        NGAYSINH = TO_DATE(p_ngaysinh, 'DD/MM/YYYY'),
        SDT = p_sdt,
        DIACHI = p_diachi,
        VAITRO = p_vaitro
    WHERE UPPER(USERNAME) = UPPER(p_username);

    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE_APPLICATION_ERROR(-20002, 'Loi cap nhat thong tin User: ' || SQLERRM);
END sp_UpdateUserInfo;
/

-- ==========================================================
-- STORED PROCEDURES BO SUNG (CHUYEN NGHIEP VU TU C# XUONG ORACLE)
-- Chay voi quyen SYSDBA / DBA (truy cap DBA_OBJECTS, DBA_SYS_PRIVS, ALL_TAB_COLUMNS)
-- ==========================================================

-- USP_GET_SCHEMA_OBJECTS: Lay danh sach object trong schema ADMINHOS
-- (dung cho chuc nang Grant/Revoke chon doi tuong tren giao dien PH1)
CREATE OR REPLACE PROCEDURE USP_GET_SCHEMA_OBJECTS(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT OBJECT_NAME, OBJECT_TYPE
        FROM DBA_OBJECTS
        WHERE OWNER = 'ADMINHOS'
          AND OBJECT_TYPE IN ('TABLE', 'VIEW', 'PROCEDURE', 'FUNCTION')
          AND ORACLE_MAINTAINED = 'N'
        ORDER BY OBJECT_TYPE, OBJECT_NAME;
END;
/

-- USP_GET_TABLE_COLUMNS: Lay danh sach cot cua mot bang (dung cho ColPicker chon cot)
CREATE OR REPLACE PROCEDURE USP_GET_TABLE_COLUMNS(
    p_table_name IN  VARCHAR2,
    p_cursor     OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT COLUMN_NAME, DATA_TYPE, NULLABLE
        FROM ALL_TAB_COLUMNS
        WHERE TABLE_NAME = UPPER(p_table_name)
        ORDER BY COLUMN_ID;
END;
/

-- USP_GET_SYS_PRIVS: Lay danh sach system privilege cua mot user/role
CREATE OR REPLACE PROCEDURE USP_GET_SYS_PRIVS(
    p_grantee IN  VARCHAR2,
    p_cursor  OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT GRANTEE, PRIVILEGE, ADMIN_OPTION
        FROM DBA_SYS_PRIVS
        WHERE GRANTEE = UPPER(p_grantee)
        ORDER BY PRIVILEGE;
END;
/

-- USP_COUNT_SYS_PRIVS: Dem so system privilege cua mot user/role
CREATE OR REPLACE PROCEDURE USP_COUNT_SYS_PRIVS(
    p_grantee IN  VARCHAR2,
    p_count   OUT NUMBER
) AS
BEGIN
    SELECT COUNT(*)
    INTO   p_count
    FROM   DBA_SYS_PRIVS
    WHERE  GRANTEE = UPPER(p_grantee);
END;
/

-- ==========================================================
-- DEMO DATA - PHÂN HỆ 1: QUẢN TRỊ NGƯỜI DÙNG & BẢO MẬT
-- ==========================================================
-- 1. DỮ LIỆU MẪU ĐỂ TEST
EXEC SP_CREATEUSER('BS_AN', '123',  N'Nguyễn Văn An', 'SYSTEM');
EXEC SP_CREATEUSER('YT_BINH', '123',  N'Lê Thị Bình', 'SYSTEM');

INSERT INTO LUONG_NHANVIEN VALUES ('BS_AN', 20000000, 5000000, 2000000, 23000000, '04/2026');
INSERT INTO LUONG_NHANVIEN VALUES ('YT_BINH', 10000000, 2000000, 500000, 11500000, '04/2026');
COMMIT;

EXEC sp_UpdateUserInfo('BS_AN', N'Nguyễn Văn An', N'Nam', '15/05/1985', '0901234567', N'123 Đường Lê Lợi, Quận 1, TP.HCM', N'Bác sĩ');
EXEC sp_UpdateUserInfo('YT_BINH', N'Lê Thị Bình', N'Nữ', '20/10/1992', '0988776655', N'456 Đường Nguyễn Huệ, Quận 1, TP.HCM', N'Y tá');


-- 2. TẠO CÁC ĐỐI TƯỢNG ĐA DẠNG ĐỂ TEST PHÂN QUYỀN

-- --- A. VIEW (Dùng để test SELECT mức Table/View) ---

-- 1. View xem danh sách nhân viên công khai (không hiện địa chỉ, sdt)
CREATE OR REPLACE VIEW V_DANH_SACH_NHAN_VIEN AS
SELECT USERNAME, HOTEN, VAITRO FROM THONGTIN_NHANVIEN;

-- 2. View xem tổng hợp thu nhập (dùng để test VPD hoặc phân quyền mức cột sau này)
CREATE OR REPLACE VIEW V_TONG_HOP_THU_NHAP AS
SELECT USERNAME, LUONG_THUC_LANH, THANG_NAM FROM LUONG_NHANVIEN;


-- --- B. PROCEDURE (Dùng để test quyền EXECUTE) ---

-- 1. Proc đơn giản để cập nhật số điện thoại
CREATE OR REPLACE PROCEDURE SP_UPDATE_PHONE (p_user IN VARCHAR2, p_phone IN VARCHAR2) AS
BEGIN
    UPDATE THONGTIN_NHANVIEN SET SDT = p_phone WHERE USERNAME = UPPER(p_user);
    COMMIT;
END;
/

-- 2. Proc làm mới bảng lương (giả lập)
CREATE OR REPLACE PROCEDURE SP_REFRESH_SALARY AS
BEGIN
    DBMS_OUTPUT.PUT_LINE('Bang luong da duoc lam moi.');
END;
/


-- --- C. FUNCTION (Dùng để test quyền EXECUTE trên Function) ---

-- 1. Hàm tính tổng thu nhập (Lương + Phụ cấp)
CREATE OR REPLACE FUNCTION FN_TINH_TONG_THU_NHAP (p_user IN VARCHAR2) RETURN NUMBER AS
    v_total NUMBER;
BEGIN
    SELECT (LUONG_CO_BAN + PHU_CAP) INTO v_total FROM LUONG_NHANVIEN WHERE USERNAME = UPPER(p_user);
    RETURN v_total;
EXCEPTION WHEN NO_DATA_FOUND THEN RETURN 0;
END;
/

-- 2. Hàm lấy tên nhân viên từ Username
CREATE OR REPLACE FUNCTION FN_GET_FULLNAME (p_user IN VARCHAR2) RETURN NVARCHAR2 AS
    v_name NVARCHAR2(100);
BEGIN
    SELECT HOTEN INTO v_name FROM THONGTIN_NHANVIEN WHERE USERNAME = UPPER(p_user);
    RETURN v_name;
EXCEPTION WHEN NO_DATA_FOUND THEN RETURN 'N/A';
END;
/

-- ==========================================================
-- KIỂM TRA (DÙNG KIỂM TRA 5 YÊU CẦU TRÊN)
-- ==========================================================
--EXEC sp_CreateUser('TEST_USER_1', '123456');
--EXEC sp_CreateUser('TEST_USER_2', '123');
--EXEC sp_CreateUser('TEST_USER_3', '123');
---- Sau đó kiểm tra xem user đã có trong máy chưa
--SELECT username FROM dba_users WHERE username = 'TEST_USER_1';
--EXEC sp_changeuserpassword('TEST_USER_1', '123');
---- Test tạo Role
--EXEC sp_CreateRole('ROLE_KETOAN');
--SELECT role FROM dba_roles WHERE role = 'ROLE_KETOAN';
--
---- Test lấy danh sách User
--VARIABLE cur_user REFCURSOR;
--EXEC USP_LIST_USERS(:cur_user);
--PRINT cur_user;
--
---- Test lấy danh sách Role
--VARIABLE cur_role REFCURSOR;
--EXEC USP_LIST_ROLES(:cur_role);
--PRINT cur_role;
--
---- Tạo bảng mẫu để test
--CREATE TABLE NHANVIEN_MAU (ID NUMBER, HOTEN VARCHAR2(50), LUONG NUMBER);
--INSERT INTO NHANVIEN_MAU VALUES (1, 'Nguyen Van A', 5000);
--INSERT INTO NHANVIEN_MAU VALUES (2, 'Le Thi B', 7000);
--COMMIT;
--
---- Test cấp role
--EXEC sp_grant_role_to_user('ROLE_KETOAN', 'TEST_USER_1', 'NO')
--EXEC sp_grant_role_to_user('ROLE_YTA', 'TEST_USER_1', 'NO')

--
---- Test cấp quyền SELECT trên cột HOTEN cho TEST_USER_1
--EXEC SP_GRANT_PRIVILEGE('SELECT', 'TABLE', 'NHANVIEN_MAU', 'HOTEN', 'TEST_USER_1', 'USER', 'YES');
--EXEC SP_GRANT_PRIVILEGE('UPDATE', 'TABLE', 'NHANVIEN_MAU', 'HOTEN', 'TEST_USER_1', 'USER', 'YES');
--
---- TEST QUYỀN 
--SELECT * FROM ADMINHOS.NHANVIEN_MAU;
--
---- ĐC
--UPDATE ADMINHOS.NHANVIEN_MAU 
--SET HOTEN = 'Ten Moi' 
--WHERE ID = 1;
--
---- LỖI (K CÓ QUYỀN)
--UPDATE ADMINHOS.NHANVIEN_MAU 
--SET LUONG = 2000
--WHERE ID = 1;
--
---- Thu hồi quyền 
--EXEC sp_revoke_privilege('OBJECT', 'SELECT', 'NHANVIEN_MAU', 'TEST_USER_1');
--EXEC sp_revoke_privilege('OBJECT', 'UPDATE', 'NHANVIEN_MAU', 'TEST_USER_1');
--
---- Thu hồi Role
--EXEC sp_revoke_privilege('ROLE', 'ROLE_KETOAN', NULL, 'TEST_USER_1');
--
---- Xem các quyền đối tượng của TEST_USER_1
--VARIABLE res_obj REFCURSOR;
--EXEC USP_GET_OBJ_PRIVS('TEST_USER_1', :res_obj);
--PRINT res_obj;
--
---- Xem các Role của TEST_USER_1
--VARIABLE res_role REFCURSOR;
--EXEC USP_GET_ROLE_PRIVS('TEST_USER_1', :res_role);
--PRINT res_role;
--
---- XEM POLICY
----SELECT 
----    OBJECT_OWNER, 
----    OBJECT_NAME, 
----    POLICY_NAME,
----    ENABLE 
----FROM ALL_POLICIES
----WHERE OBJECT_OWNER = 'ADMINHOS'; -- Lọc theo schema của bạn
--
--
--SELECT OBJECT_NAME, POLICY_NAME, ENABLE 
--FROM ALL_POLICIES 
--WHERE POLICY_NAME LIKE 'VPD_SEL_TEST_USER_1%';

--SELECT * FROM THONGTIN_NHANVIEN;
--
--SELECT * FROM DBA_ROLES;
--
--SELECT GRANTEE, TABLE_NAME, PRIVILEGE
--FROM DBA_TAB_PRIVS tp
--WHERE 
--    -- 1. Quyền cấp cho User (Lọc user hệ thống)
--    tp.GRANTEE IN (SELECT USERNAME FROM DBA_USERS WHERE ORACLE_MAINTAINED = 'N')
--    OR 
--    -- 2. Quyền cấp cho Role (Lọc role hệ thống)
--    tp.GRANTEE IN (SELECT ROLE FROM DBA_ROLES WHERE ORACLE_MAINTAINED = 'N');

--SELECT SDT FROM ADMINHOS.THONGTIN_NHANVIEN;
--EXEC SP_REVOKE_PRIVILEGE('TABLE','SELECT','NHANVIEN_MAU','BS_AN','HOTEN, LUONG');
--EXEC SP_GRANT_PRIVILEGE('SELECT','TABLE','NHANVIEN_MAU','HOTEN','BS_AN','USER','NO');
--SELECT * FROM ADMINHOS.NHANVIEN_MAU;
--
---- 2. Kiểm tra policy đã được tạo sau khi GRANT
--SELECT POLICY_NAME, OBJECT_NAME, FUNCTION
--FROM DBA_POLICIES 
--WHERE OBJECT_OWNER = 'ADMINHOS';
--
--SELECT * FROM VPD_COL_TRACKING;

-- ====================================================================
-- CHẠY ĐOẠN SAU XÓA SẠCH DỰ ÁN RỒI COMMENT LẠI CTRL+A CHẠY FULL SCRIPT 
-- (CHẠY VỚI QUYỀN SYS - CÓ ĐOẠN TỰ CHUYỂN SANG ADMINHOS)
-- ====================================================================
-- 0. Chuyển vào đúng PDB của dự án
--ALTER SESSION SET CONTAINER = PDBHOSX;
--
---- 1. Xóa các chính sách bảo mật (VPD Policies)
---- Việc này quan trọng vì nếu không xóa Policy, bạn sẽ không thể DROP bảng dễ dàng
--BEGIN
--    FOR rec IN (SELECT object_name, policy_name FROM dba_policies WHERE object_owner = 'SYS')
--    LOOP
--        DBMS_RLS.DROP_POLICY('SYS', rec.object_name, rec.policy_name);
--    END LOOP;
--END;
--/
--
---- 2. Xóa toàn bộ các bảng nghiệp vụ lỡ tạo trong Schema SYS
---- Dùng CASCADE CONSTRAINTS PURGE để xóa sạch cả ràng buộc và dọn thùng rác (recyclebin)
--BEGIN EXECUTE IMMEDIATE 'DROP TABLE VPD_COL_TRACKING CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP TABLE LUONG_NHANVIEN CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP TABLE THONGTIN_NHANVIEN CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP TABLE NHANVIEN_MAU CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--
---- 3. Xóa các View, Procedure, Function lỡ tạo trong SYS
--BEGIN EXECUTE IMMEDIATE 'DROP VIEW V_DANH_SACH_NHAN_VIEN'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP VIEW V_TONG_HOP_THU_NHAP'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP PROCEDURE SP_UPDATE_PHONE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP PROCEDURE SP_REFRESH_SALARY'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP FUNCTION FN_TINH_TONG_THU_NHAP'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP FUNCTION FN_GET_FULLNAME'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP FUNCTION POLICY_SELECT_COLUMN'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--
---- 4. Xóa các User mẫu và Role (Xóa tận gốc)
--BEGIN EXECUTE IMMEDIATE 'DROP USER BS_AN CASCADE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP USER YT_BINH CASCADE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP USER TEST_USER_1 CASCADE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP USER TEST_USER_2 CASCADE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP USER TEST_USER_3 CASCADE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--BEGIN EXECUTE IMMEDIATE 'DROP ROLE ROLE_KETOAN'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--
---- 5. Cuối cùng, xóa luôn adminHos (để tạo lại cho sạch từ đầu)
--BEGIN EXECUTE IMMEDIATE 'DROP USER adminHos CASCADE'; EXCEPTION WHEN OTHERS THEN NULL; END;
--/
--
--COMMIT;
--
--
---- Chuyển vào đúng PDB
--ALTER SESSION SET CONTAINER = PDBHOSX;
--
---- Tìm và giết các session của adminHos (nếu có)
--BEGIN
--   FOR r IN (SELECT sid, serial# FROM v$session WHERE username = 'ADMINHOS')
--   LOOP
--      EXECUTE IMMEDIATE 'ALTER SYSTEM KILL SESSION ''' || r.sid || ',' || r.serial# || ''' IMMEDIATE';
--END LOOP;
--END;
