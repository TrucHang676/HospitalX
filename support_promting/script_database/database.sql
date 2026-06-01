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
-- PHÂN HỆ 2: ỨNG DỤNG QUẢN LÝ DỮ LIỆU Y TẾ
-- YÊU CẦU 1 - CÂU 1:
-- Cài đặt cơ sở dữ liệu và thiết lập tài khoản theo mô tả TC#1
-- ==========================================================


-- ==========================================================
-- PHẦN 1. THIẾT LẬP BAN ĐẦU - CHẠY BẰNG SYSDBA
-- ==========================================================

SET SERVEROUTPUT ON;

-- Chuyển sang PDB của dự án
ALTER SESSION SET CONTAINER = PDBHOSX;


-- ==========================================================
-- 1. XÓA TÀI KHOẢN NHÂN VIÊN VÀ BỆNH NHÂN ĐÃ TẠO
-- ==========================================================
DECLARE
    v_dropped NUMBER := 0;
BEGIN
    FOR r IN (
        SELECT USERNAME
        FROM DBA_USERS
        WHERE REGEXP_LIKE(USERNAME, '^(DP[0-9]{4}|BS[0-9]{4}|KTV[0-9]{3}|BN[0-9]{6})$')
        ORDER BY USERNAME
    )
    LOOP
        EXECUTE IMMEDIATE 'DROP USER ' || r.USERNAME || ' CASCADE';
        v_dropped := v_dropped + 1;
    END LOOP;

    DBMS_OUTPUT.PUT_LINE('So tai khoan da xoa: ' || v_dropped);
END;
/


-- ==========================================================
-- 2. ĐẢM BẢO USER QUẢN TRỊ adminHos TỒN TẠI
-- ==========================================================
DECLARE
    v_count NUMBER;
BEGIN
    -- Kiểm tra user adminHos đã tồn tại chưa
    SELECT COUNT(*)
    INTO v_count
    FROM DBA_USERS
    WHERE USERNAME = 'ADMINHOS';

    -- Nếu chưa có thì tạo mới, nếu có rồi thì mở khóa và đặt lại mật khẩu
    IF v_count = 0 THEN
        EXECUTE IMMEDIATE 'CREATE USER adminHos IDENTIFIED BY "123" ACCOUNT UNLOCK';
    ELSE
        EXECUTE IMMEDIATE 'ALTER USER adminHos IDENTIFIED BY "123" ACCOUNT UNLOCK';
    END IF;
END;
/


-- ==========================================================
-- 3. CẤP QUYỀN CHO adminHos
-- ==========================================================

GRANT DBA TO adminHos;
GRANT CREATE SESSION TO adminHos;

GRANT CREATE USER TO adminHos;
GRANT ALTER USER TO adminHos;
GRANT DROP USER TO adminHos;

GRANT CREATE ROLE TO adminHos;
GRANT DROP ANY ROLE TO adminHos;
GRANT GRANT ANY ROLE TO adminHos;
GRANT GRANT ANY PRIVILEGE TO adminHos;

GRANT CREATE TABLE TO adminHos;
GRANT CREATE VIEW TO adminHos;
GRANT CREATE PROCEDURE TO adminHos;
GRANT CREATE TRIGGER TO adminHos;
GRANT UNLIMITED TABLESPACE TO adminHos;

GRANT ALTER SESSION TO adminHos;
GRANT SELECT ANY DICTIONARY TO adminHos;

-- Chuyển sang user quản trị ứng dụng
CONN adminHos/123@localhost:1521/PDBHOSX


-- ==========================================================
-- PHẦN 2. CÀI ĐẶT CSDL Y TẾ VÀ TÀI KHOẢN THEO TC#1
-- ==========================================================

SET SERVEROUTPUT ON;

-- Username Oracle của nhân viên = MANV trong NHANVIEN
-- Username Oracle của bệnh nhân = MABN trong BENHNHAN


-- ==========================================================
-- 1. XÓA OBJECT CŨ NẾU ĐÃ TỒN TẠI
-- ==========================================================

BEGIN EXECUTE IMMEDIATE 'DROP TABLE DONTHUOC CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

BEGIN EXECUTE IMMEDIATE 'DROP TABLE HSBA_DV CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

BEGIN EXECUTE IMMEDIATE 'DROP TABLE HSBA CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

BEGIN EXECUTE IMMEDIATE 'DROP TABLE BENHNHAN CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

BEGIN EXECUTE IMMEDIATE 'DROP TABLE NHANVIEN CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

BEGIN EXECUTE IMMEDIATE 'DROP PROCEDURE sp_CreateHealthUser'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

BEGIN EXECUTE IMMEDIATE 'DROP PROCEDURE sp_CreateAllHealthUsers'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

-- ==========================================================
-- 2. TẠO CẤU TRÚC CSDL Y TẾ
-- ==========================================================

CREATE TABLE BENHNHAN (
    MABN            VARCHAR2(10)    PRIMARY KEY,
    TENBN           NVARCHAR2(100)  NOT NULL,
    PHAI            NVARCHAR2(4)   NOT NULL,
    NGAYSINH        DATE            NOT NULL,
    CCCD            VARCHAR2(20)    UNIQUE,
    SONHA           NVARCHAR2(50),
    TENDUONG        NVARCHAR2(100),
    QUANHUYEN       NVARCHAR2(50),
    TINHTP          NVARCHAR2(50),
    TIENSUBENH      NVARCHAR2(300),
    TIENSUBENHGD    NVARCHAR2(300),
    DIUNGTHUOC      NVARCHAR2(100),

    CONSTRAINT CK_BENHNHAN_PHAI
        CHECK (PHAI IN (N'Nam', N'Nữ', N'Khác'))
);


CREATE TABLE NHANVIEN (
    MANV            VARCHAR2(10)    PRIMARY KEY,
    HOTEN           NVARCHAR2(100)  NOT NULL,
    PHAI            NVARCHAR2(4)   NOT NULL,
    NGAYSINH        DATE            NOT NULL,
    CMND            VARCHAR2(20)    UNIQUE,
    QUEQUAN         NVARCHAR2(100),
    SODT            VARCHAR2(15),
    VAITRO          NVARCHAR2(50)   NOT NULL,
    CHUYENKHOA      NVARCHAR2(100),

    CONSTRAINT CK_NHANVIEN_PHAI
        CHECK (PHAI IN (N'Nam', N'Nữ', N'Khác')),

    CONSTRAINT CK_NHANVIEN_VAITRO
        CHECK (VAITRO IN (
            N'Điều phối viên',
            N'Bác sĩ/Y sĩ',
            N'Kỹ thuật viên',
            N'Bệnh nhân'
        ))
);


CREATE TABLE HSBA (
    MAHSBA          VARCHAR2(10)    PRIMARY KEY,
    MABN            VARCHAR2(10)    NOT NULL,
    NGAY            DATE            NOT NULL,
    CHANDOAN        NVARCHAR2(200),
    DIEUTRI         NVARCHAR2(200),
    MABS            VARCHAR2(10),
    MAKHOA          VARCHAR2(10),
    KETLUAN         NVARCHAR2(200),

    CONSTRAINT FK_HSBA_BENHNHAN
        FOREIGN KEY (MABN) REFERENCES BENHNHAN(MABN),

    CONSTRAINT FK_HSBA_BACSI
        FOREIGN KEY (MABS) REFERENCES NHANVIEN(MANV)
);


CREATE TABLE HSBA_DV (
    MAHSBA          VARCHAR2(10)    NOT NULL,
    LOAIDV          NVARCHAR2(100)  NOT NULL,
    NGAYDV          DATE            NOT NULL,
    MAKTV           VARCHAR2(10),
    KETQUA          NVARCHAR2(200),

    CONSTRAINT PK_HSBA_DV
        PRIMARY KEY (MAHSBA, LOAIDV, NGAYDV),

    CONSTRAINT FK_HSBADV_HSBA
        FOREIGN KEY (MAHSBA) REFERENCES HSBA(MAHSBA),

    CONSTRAINT FK_HSBADV_KTV
        FOREIGN KEY (MAKTV) REFERENCES NHANVIEN(MANV)
);


CREATE TABLE DONTHUOC (
    MAHSBA          VARCHAR2(10)    NOT NULL,
    NGAYDT          DATE            NOT NULL,
    TENTHUOC        NVARCHAR2(100)  NOT NULL,
    LIEUDUNG        NVARCHAR2(100),

    CONSTRAINT PK_DONTHUOC
        PRIMARY KEY (MAHSBA, NGAYDT, TENTHUOC),

    CONSTRAINT FK_DONTHUOC_HSBA
        FOREIGN KEY (MAHSBA) REFERENCES HSBA(MAHSBA)
);


-- ==========================================================
-- 3. NHẬP DỮ LIỆU MẪU
-- ==========================================================

-- 20 điều phối viên
INSERT INTO NHANVIEN (
    MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA
)
SELECT
    'DP' || LPAD(LEVEL, 4, '0'),
    N'Điều phối viên ' || TO_NCHAR(LEVEL),
    CASE WHEN MOD(LEVEL, 2) = 0 THEN N'Nữ' ELSE N'Nam' END,
    DATE '1990-01-01' + LEVEL,
    '07901' || LPAD(LEVEL, 7, '0'),
    N'Hồ Chí Minh',
    '0901' || LPAD(LEVEL, 6, '0'),
    N'Điều phối viên',
    NULL
FROM DUAL
CONNECT BY LEVEL <= 20;


-- 100 bác sĩ/y sĩ
INSERT INTO NHANVIEN (
    MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA
)
SELECT
    'BS' || LPAD(LEVEL, 4, '0'),
    N'Bác sĩ/Y sĩ ' || TO_NCHAR(LEVEL),
    CASE WHEN MOD(LEVEL, 2) = 0 THEN N'Nữ' ELSE N'Nam' END,
    DATE '1985-01-01' + LEVEL,
    '07902' || LPAD(LEVEL, 7, '0'),
    N'Hồ Chí Minh',
    '0911' || LPAD(LEVEL, 6, '0'),
    N'Bác sĩ/Y sĩ',
    CASE
        WHEN MOD(LEVEL, 3) = 0 THEN N'Khoa tiêu hóa'
        WHEN MOD(LEVEL, 3) = 1 THEN N'Khoa thần kinh'
        ELSE N'Khoa tim mạch'
    END
FROM DUAL
CONNECT BY LEVEL <= 100;


-- 50 kỹ thuật viên
INSERT INTO NHANVIEN (
    MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA
)
SELECT
    'KTV' || LPAD(LEVEL, 3, '0'),
    N'Kỹ thuật viên ' || TO_NCHAR(LEVEL),
    CASE WHEN MOD(LEVEL, 2) = 0 THEN N'Nữ' ELSE N'Nam' END,
    DATE '1992-01-01' + LEVEL,
    '07903' || LPAD(LEVEL, 7, '0'),
    N'Hồ Chí Minh',
    '0921' || LPAD(LEVEL, 6, '0'),
    N'Kỹ thuật viên',
    CASE
        WHEN MOD(LEVEL, 3) = 0 THEN N'Khoa tiêu hóa'
        WHEN MOD(LEVEL, 3) = 1 THEN N'Khoa thần kinh'
        ELSE N'Khoa tim mạch'
    END
FROM DUAL
CONNECT BY LEVEL <= 50;


-- 100000 bệnh nhân
INSERT INTO BENHNHAN (
    MABN, TENBN, PHAI, NGAYSINH, CCCD,
    SONHA, TENDUONG, QUANHUYEN, TINHTP,
    TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC
)
SELECT
    'BN' || LPAD(LEVEL, 6, '0'),
    N'Bệnh nhân ' || TO_NCHAR(LEVEL),
    CASE WHEN MOD(LEVEL, 2) = 0 THEN N'Nữ' ELSE N'Nam' END,
    DATE '1970-01-01' + MOD(LEVEL, 15000),
    '079' || LPAD(LEVEL, 9, '0'),
    TO_NCHAR(MOD(LEVEL, 300) + 1),
    N'Đường số ' || TO_NCHAR(MOD(LEVEL, 50) + 1),
    CASE
        WHEN MOD(LEVEL, 3) = 0 THEN N'Quận 1'
        WHEN MOD(LEVEL, 3) = 1 THEN N'Quận 3'
        ELSE N'Quận 5'
    END,
    N'Hồ Chí Minh',
    N'Chưa ghi nhận',
    N'Chưa ghi nhận',
    N'Không'
FROM DUAL
CONNECT BY LEVEL <= 100000;


-- 100 hồ sơ bệnh án mẫu
INSERT INTO HSBA (
    MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN
)
SELECT
    'HSBA' || LPAD(LEVEL, 5, '0'),
    'BN' || LPAD(LEVEL, 6, '0'),
    DATE '2026-05-01' + LEVEL,
    N'Chẩn đoán ban đầu ' || TO_NCHAR(LEVEL),
    N'Hướng điều trị ' || TO_NCHAR(LEVEL),
    'BS' || LPAD(MOD(LEVEL - 1, 100) + 1, 4, '0'),
    CASE
        WHEN MOD(LEVEL, 3) = 0 THEN 'KTH' --khoa tiêu hóa
        WHEN MOD(LEVEL, 3) = 1 THEN 'KTK' --khoa thần kinh
        ELSE 'KTM'  --khoa tim mạch
    END,
    N'Đang theo dõi'
FROM DUAL
CONNECT BY LEVEL <= 100;


-- 100 dịch vụ hỗ trợ chẩn đoán mẫu
INSERT INTO HSBA_DV (
    MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA
)
SELECT
    'HSBA' || LPAD(LEVEL, 5, '0'),
    CASE
        WHEN MOD(LEVEL, 3) = 0 THEN N'Xét nghiệm máu'
        WHEN MOD(LEVEL, 3) = 1 THEN N'Chụp X-Quang'
        ELSE N'Siêu âm'
    END,
    DATE '2026-05-10' + LEVEL,
    'KTV' || LPAD(MOD(LEVEL - 1, 50) + 1, 3, '0'),
    N'Chưa có kết quả'
FROM DUAL
CONNECT BY LEVEL <= 100;


-- 100 đơn thuốc mẫu
INSERT INTO DONTHUOC (
    MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
)
SELECT
    'HSBA' || LPAD(LEVEL, 5, '0'),
    DATE '2026-05-15' + LEVEL,
    N'Thuốc ' || TO_NCHAR(LEVEL),
    N'Uống 2 lần/ngày'
FROM DUAL
CONNECT BY LEVEL <= 100;

COMMIT;


-- ==========================================================
-- 4. TẠO TÀI KHOẢN ORACLE CHO NHÂN VIÊN VÀ BỆNH NHÂN DEMO
-- ==========================================================

CREATE OR REPLACE PROCEDURE sp_CreateHealthUser (
    p_username IN VARCHAR2,
    p_password IN VARCHAR2 DEFAULT 'Hos@123456'
)
AS
    v_count    NUMBER;
    v_username VARCHAR2(30);
    v_password VARCHAR2(200);
    v_sql      VARCHAR2(1000);
BEGIN
    v_username := UPPER(TRIM(p_username));
    v_password := REPLACE(p_password, '"', '""');

    IF v_username IS NULL
       OR LENGTH(v_username) > 30
       OR NOT REGEXP_LIKE(v_username, '^[A-Z][A-Z0-9_]*$') THEN
        RAISE_APPLICATION_ERROR(-20001, 'Username khong hop le: ' || p_username);
    END IF;

    SELECT COUNT(*)
    INTO v_count
    FROM DBA_USERS
    WHERE USERNAME = v_username;

    IF v_count = 0 THEN
        v_sql := 'CREATE USER ' || v_username ||
                 ' IDENTIFIED BY "' || v_password || '" ACCOUNT UNLOCK';

        EXECUTE IMMEDIATE v_sql;
    ELSE
        v_sql := 'ALTER USER ' || v_username ||
                 ' IDENTIFIED BY "' || v_password || '" ACCOUNT UNLOCK';

        EXECUTE IMMEDIATE v_sql;
    END IF;

    EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO ' || v_username;
END;
/


CREATE OR REPLACE PROCEDURE sp_CreateAllHealthUsers (
    p_so_tk_benhnhan_demo IN NUMBER DEFAULT 100
)
AS
    v_count_nv NUMBER := 0;
    v_count_bn NUMBER := 0;
BEGIN
    -- Tạo tài khoản cho toàn bộ nhân viên
    FOR r IN (
        SELECT MANV AS USERNAME
        FROM NHANVIEN
        ORDER BY MANV
    )
    LOOP
        sp_CreateHealthUser(r.USERNAME);
        v_count_nv := v_count_nv + 1;
    END LOOP;

    -- Tạo tài khoản cho một phần bệnh nhân để demo
    FOR r IN (
        SELECT USERNAME
        FROM (
            SELECT MABN AS USERNAME
            FROM BENHNHAN
            ORDER BY MABN
        )
        WHERE ROWNUM <= p_so_tk_benhnhan_demo
    )
    LOOP
        sp_CreateHealthUser(r.USERNAME);
        v_count_bn := v_count_bn + 1;
    END LOOP;

    DBMS_OUTPUT.PUT_LINE('So tai khoan nhan vien da tao/cap nhat: ' || v_count_nv);
    DBMS_OUTPUT.PUT_LINE('So tai khoan benh nhan demo da tao/cap nhat: ' || v_count_bn);
END;
/


BEGIN
    sp_CreateAllHealthUsers(20);
END;
/


-- ==========================================================
-- 5. KIỂM TRA KẾT QUẢ CÀI ĐẶT TC#1
-- ==========================================================

-- Số lượng nhân viên
SELECT COUNT(*) AS SO_LUONG_NHANVIEN
FROM NHANVIEN;


-- Số lượng bệnh nhân
SELECT COUNT(*) AS SO_LUONG_BENHNHAN
FROM BENHNHAN;


-- Số lượng tài khoản Oracle của nhân viên
SELECT COUNT(*) AS SO_TAIKHOAN_NHANVIEN
FROM DBA_USERS U
WHERE EXISTS (
    SELECT 1
    FROM NHANVIEN NV
    WHERE NV.MANV = U.USERNAME
);


-- Số lượng tài khoản Oracle của bệnh nhân demo
SELECT COUNT(*) AS SO_TAIKHOAN_BENHNHAN
FROM DBA_USERS U
WHERE EXISTS (
    SELECT 1
    FROM BENHNHAN BN
    WHERE BN.MABN = U.USERNAME
);


-- ==========================================================
-- 6. KIỂM TRA ĐĂNG NHẬP MẪU
-- ==========================================================

-- Tài khoản mẫu:
--      Điều phối viên: DP0001 / Hos@123456
--      Bác sĩ/Y sĩ:    BS0001 / Hos@123456
--      Kỹ thuật viên:  KTV001 / Hos@123456
--      Bệnh nhân:      BN000001 / Hos@123456

-- Ví dụ:
--      CONN DP0001/"Hos@123456"@localhost:1521/PDBHOSX
--      SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER FROM DUAL;