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
SHOW CON_NAME;

--ALTER PLUGGABLE DATABASE PDBHOSX OPEN;

ALTER SESSION SET CONTAINER = PDBHOSX;

SHOW CON_NAME;


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
-- 4a. TẠO SYNONYM CÔNG CỘNG ĐỂ TÊN BẢNG KHÔNG CÓ SCHEMA TRỎ VỀ VIEW BẢO MẬT
-- Lưu ý: cần quyền CREATE PUBLIC SYNONYM (admin schema)
-- ==========================================================
 BEGIN EXECUTE IMMEDIATE 'DROP PUBLIC SYNONYM HSBA_DV'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
 BEGIN EXECUTE IMMEDIATE 'DROP PUBLIC SYNONYM BENHNHAN'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
 BEGIN EXECUTE IMMEDIATE 'DROP PUBLIC SYNONYM NHANVIEN'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
CREATE PUBLIC SYNONYM HSBA_DV FOR ADMINHOS.VW_HSBA_DV_KTV;
CREATE PUBLIC SYNONYM BENHNHAN FOR ADMINHOS.VW_BENHNHAN_SELF;
CREATE PUBLIC SYNONYM NHANVIEN FOR ADMINHOS.VW_NHANVIEN_SELF;


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
SHOW USER;
SHOW CON_NAME;

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
    COSO            NVARCHAR2(100)  NOT NULL,

    CONSTRAINT CK_NHANVIEN_PHAI
        CHECK (PHAI IN (N'Nam', N'Nữ', N'Khác')),

    CONSTRAINT CK_NHANVIEN_VAITRO
        CHECK (VAITRO IN (
            N'Điều phối viên',
            N'Bác sĩ/Y sĩ',
            N'Kỹ thuật viên',
            N'Bệnh nhân'
        )),
        
    CONSTRAINT CK_NHANVIEN_COSO
        CHECK (COSO IN (
            N'Hà Nội',
            N'Hải Phòng',
            N'Hồ Chí Minh'
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
    MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA, COSO
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
    NULL,
    CASE
        WHEN MOD(LEVEL, 3) = 0 THEN N'Hà Nội'
        WHEN MOD(LEVEL, 3) = 1 THEN N'Hồ Chí Minh'
        ELSE N'Hải Phòng'
    END
FROM DUAL
CONNECT BY LEVEL <= 20;


-- 100 bác sĩ/y sĩ
INSERT INTO NHANVIEN (
    MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA, COSO
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
    CASE MOD(MOD(LEVEL, 3) + FLOOR((LEVEL - 1) / 3), 3)
        WHEN 0 THEN N'Khoa tiêu hóa'
        WHEN 1 THEN N'Khoa thần kinh'
        ELSE N'Khoa tim mạch'
    END,
    CASE
        WHEN MOD(LEVEL, 3) = 0 THEN N'Hà Nội'
        WHEN MOD(LEVEL, 3) = 1 THEN N'Hải Phòng'
        ELSE N'Hồ Chí Minh'
    END
FROM DUAL
CONNECT BY LEVEL <= 100;


-- 50 kỹ thuật viên
INSERT INTO NHANVIEN (
    MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA, COSO
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
    CASE MOD(MOD(LEVEL, 3) + FLOOR((LEVEL - 1) / 3), 3)
        WHEN 0 THEN N'Khoa tiêu hóa'
        WHEN 1 THEN N'Khoa thần kinh'
        ELSE N'Khoa tim mạch'
    END,
    CASE
        WHEN MOD(LEVEL, 3) = 0 THEN N'Hà Nội'
        WHEN MOD(LEVEL, 3) = 1 THEN N'Hải Phòng'
        ELSE N'Hồ Chí Minh'
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

UPDATE ADMINHOS.NHANVIEN
SET 
    CHUYENKHOA = N'Khoa tiêu hóa',
    COSO = N'Hồ Chí Minh'
WHERE MANV = 'KTV001';

UPDATE ADMINHOS.NHANVIEN
SET 
    CHUYENKHOA = N'Khoa tiêu hóa',
    COSO = N'Hồ Chí Minh'
WHERE MANV = 'BS0001';

UPDATE ADMINHOS.NHANVIEN
SET 
    COSO = N'Hồ Chí Minh'
WHERE MANV = 'DP0001';

COMMIT;

-- ==========================================================
-- 4. TẠO VIEW VÀ ROLE RBAC CHO KỸ THUẬT VIÊN VÀ BỆNH NHÂN
-- ==========================================================

-- View cho bệnh nhân chỉ thấy dữ liệu của chính mình
CREATE OR REPLACE VIEW VW_BENHNHAN_SELF AS
SELECT MABN, TENBN, PHAI, NGAYSINH, CCCD,
       SONHA, TENDUONG, QUANHUYEN, TINHTP,
       TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC
FROM BENHNHAN
WHERE MABN = SYS_CONTEXT('USERENV','SESSION_USER');
/

-- View cho kỹ thuật viên chỉ thấy dịch vụ mình thực hiện
CREATE OR REPLACE VIEW VW_HSBA_DV_KTV AS
SELECT MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA
FROM HSBA_DV
WHERE MAKTV = SYS_CONTEXT('USERENV','SESSION_USER');
/

-- View cho nhân viên chỉ thấy chính mình và chỉ cho phép cập nhật các trường được cho phép
CREATE OR REPLACE VIEW VW_NHANVIEN_SELF AS
SELECT MANV, HOTEN, PHAI, NGAYSINH, CMND,
       QUEQUAN, SODT, VAITRO, CHUYENKHOA, COSO
FROM NHANVIEN
WHERE MANV = SYS_CONTEXT('USERENV','SESSION_USER');
/

BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ROLE_KYTHUATVIEN';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ROLE_BENHNHAN';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ROLE_NHANVIEN';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

CREATE ROLE ROLE_KYTHUATVIEN;
CREATE ROLE ROLE_BENHNHAN;
CREATE ROLE ROLE_NHANVIEN;

-- Cấp quyền trên view. Các cập nhật trên view sẽ được chuyển xuống bảng gốc
GRANT SELECT ON VW_HSBA_DV_KTV TO ROLE_KYTHUATVIEN;
GRANT UPDATE (KETQUA) ON VW_HSBA_DV_KTV TO ROLE_KYTHUATVIEN;

GRANT SELECT ON VW_NHANVIEN_SELF TO ROLE_NHANVIEN;
GRANT UPDATE (QUEQUAN, SODT) ON VW_NHANVIEN_SELF TO ROLE_NHANVIEN;

GRANT SELECT ON VW_BENHNHAN_SELF TO ROLE_BENHNHAN;
GRANT UPDATE (SONHA, TENDUONG, QUANHUYEN, TINHTP, TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC)
    ON VW_BENHNHAN_SELF TO ROLE_BENHNHAN;

-- Audit Oracle policy: ghi vết mọi cập nhật trên trường KETQUA của HSBA_DV
BEGIN
    BEGIN
        DBMS_FGA.DROP_POLICY(
            object_schema => 'ADMINHOS',
            object_name   => 'HSBA_DV',
            policy_name   => 'FGA_AUDIT_HSBA_DV_KETQUA'
        );
    EXCEPTION
        WHEN OTHERS THEN
            NULL;
    END;

    DBMS_FGA.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'HSBA_DV',
        policy_name     => 'FGA_AUDIT_HSBA_DV_KETQUA',
        audit_condition => NULL,
        audit_column    => 'KETQUA',
        statement_types => 'UPDATE',
        audit_trail     => DBMS_FGA.DB
    );
    DBMS_OUTPUT.PUT_LINE('Created FGA policy for HSBA_DV.KETQUA updates');
END;
/

-- INSTEAD OF trigger cho view VW_HSBA_DV_KTV: chuyển update KETQUA xuống HSBA_DV
CREATE OR REPLACE TRIGGER TRG_VW_HSBA_DV_KTV_UPD
INSTEAD OF UPDATE ON VW_HSBA_DV_KTV
FOR EACH ROW
BEGIN
    -- Chỉ xử lý khi KETQUA thực sự thay đổi
    IF NVL(:OLD.KETQUA, '<<NULL>>') != NVL(:NEW.KETQUA, '<<NULL>>') THEN
        -- đảm bảo người thao tác là MAKTV của bản ghi (bảo vệ thêm)
        IF SYS_CONTEXT('USERENV','SESSION_USER') != NVL(:OLD.MAKTV, ' ') THEN
            RAISE_APPLICATION_ERROR(-20002, 'Khong co quyen cap nhat dong nay');
        END IF;

        UPDATE HSBA_DV
        SET KETQUA = :NEW.KETQUA
        WHERE MAHSBA = :OLD.MAHSBA
          AND LOAIDV = :OLD.LOAIDV
          AND NGAYDV = :OLD.NGAYDV;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20003, 'Ban ghi can cap nhat khong ton tai');
        END IF;
    END IF;
END;
/

-- INSTEAD OF trigger cho view VW_NHANVIEN_SELF: chuyển update các trường được phép xuống NHANVIEN
CREATE OR REPLACE TRIGGER TRG_VW_NHANVIEN_SELF_UPD
INSTEAD OF UPDATE ON VW_NHANVIEN_SELF
FOR EACH ROW
BEGIN
    IF SYS_CONTEXT('USERENV','SESSION_USER') != NVL(:OLD.MANV, ' ') THEN
        RAISE_APPLICATION_ERROR(-20006, 'Khong co quyen cap nhat thong tin nhan vien nay');
    END IF;

    UPDATE NHANVIEN
    SET QUEQUAN = NVL(:NEW.QUEQUAN, :OLD.QUEQUAN),
        SODT = NVL(:NEW.SODT, :OLD.SODT)
    WHERE MANV = :OLD.MANV;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20007, 'Ho so nhan vien khong ton tai');
    END IF;
END;
/

-- INSTEAD OF trigger cho view VW_BENHNHAN_SELF: chuyển update các trường thông tin cá nhân xuống BENHNHAN
CREATE OR REPLACE TRIGGER TRG_VW_BENHNHAN_SELF_UPD
INSTEAD OF UPDATE ON VW_BENHNHAN_SELF
FOR EACH ROW
BEGIN
    -- chỉ cho phép người dùng cập nhật chính hồ sơ của mình
    IF SYS_CONTEXT('USERENV','SESSION_USER') != NVL(:OLD.MABN, ' ') THEN
        RAISE_APPLICATION_ERROR(-20004, 'Khong co quyen cap nhat thong tin benh nhan nay');
    END IF;

    UPDATE BENHNHAN
    SET SONHA = NVL(:NEW.SONHA, :OLD.SONHA),
        TENDUONG = NVL(:NEW.TENDUONG, :OLD.TENDUONG),
        QUANHUYEN = NVL(:NEW.QUANHUYEN, :OLD.QUANHUYEN),
        TINHTP = NVL(:NEW.TINHTP, :OLD.TINHTP),
        TIENSUBENH = NVL(:NEW.TIENSUBENH, :OLD.TIENSUBENH),
        TIENSUBENHGD = NVL(:NEW.TIENSUBENHGD, :OLD.TIENSUBENHGD),
        DIUNGTHUOC = NVL(:NEW.DIUNGTHUOC, :OLD.DIUNGTHUOC)
    WHERE MABN = :OLD.MABN;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20005, 'Ho so benh nhan khong ton tai');
    END IF;
END;
/

CREATE OR REPLACE PROCEDURE sp_GrantHealthRoles AS
BEGIN
    FOR r IN (
        SELECT MANV FROM NHANVIEN WHERE MANV LIKE 'KTV%'
    ) LOOP
        EXECUTE IMMEDIATE 'GRANT ROLE_KYTHUATVIEN TO ' || r.MANV;
    END LOOP;

    FOR r IN (
        SELECT MANV FROM NHANVIEN
        WHERE MANV LIKE 'DP%'
           OR MANV LIKE 'BS%'
           OR MANV LIKE 'KTV%'
        ORDER BY MANV
    ) LOOP
        EXECUTE IMMEDIATE 'GRANT ROLE_NHANVIEN TO ' || r.MANV;
    END LOOP;

    FOR r IN (
        SELECT USERNAME FROM (
            SELECT MABN AS USERNAME FROM BENHNHAN ORDER BY MABN
        ) WHERE ROWNUM <= 20
    ) LOOP
        EXECUTE IMMEDIATE 'GRANT ROLE_BENHNHAN TO ' || r.USERNAME;
    END LOOP;

    DBMS_OUTPUT.PUT_LINE('Da gan role cho KTV, nhan vien va benh nhan demo');
END;
/


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
    sp_GrantHealthRoles;
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

-- =====================================================================
-- YÊU CẦU 1 - CÂU 3
-- ÉP THỎA CHÍNH SÁCH BẢO MẬT BẰNG VPD
--
-- Vai trò xử lý:
--   1. Điều phối viên
--   2. Bác sĩ/Y sĩ
--
-- Schema owner: ADMINHOS
-- Chạy bằng user: ADMINHOS
-- =====================================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;
SET DEFINE OFF;


-- =====================================================================
-- PHẦN 1. DỌN POLICY CŨ NẾU TỒN TẠI
-- =====================================================================

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'BENHNHAN',
        policy_name   => 'VPD_YC1C3_BENHNHAN_DPV'
    );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA',
        policy_name   => 'VPD_YC1C3_HSBA_DPV'
    );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'VPD_YC1C3_HSBADV_DPV'
    );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA',
        policy_name   => 'VPD_YC1C3_HSBA_BS'
    );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'VPD_YC1C3_HSBADV_BS'
    );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'DONTHUOC',
        policy_name   => 'VPD_YC1C3_DONTHUOC_BS'
    );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'BENHNHAN',
        policy_name   => 'VPD_YC1C3_BENHNHAN_BS'
    );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/


-- Dọn package cũ nếu có
BEGIN
    EXECUTE IMMEDIATE 'DROP PACKAGE ADMINHOS.PKG_VPD_YC1C3';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/


-- =====================================================================
-- PHẦN 2. TẠO PACKAGE CHỨA CÁC HÀM POLICY VPD
-- =====================================================================
-- Ý tưởng:
--
-- 1. Điều phối viên:
--    - Được xem/thêm/sửa BENHNHAN.
--    - Được xem/thêm HSBA.
--    - Được cập nhật MAKHOA, MABS trên HSBA.
--    - Được xem HSBA_DV.
--    - Được cập nhật MAKTV trên HSBA_DV để điều phối kỹ thuật viên.
--    - Không bị lọc dòng vì điều phối viên xử lý toàn hệ thống.
--
-- 2. Bác sĩ/Y sĩ:
--    - Chỉ thấy HSBA mà MABS = user hiện tại.
--    - Chỉ thấy/thêm/xóa HSBA_DV thuộc HSBA mình phụ trách.
--    - Chỉ thấy/thêm/sửa/xóa DONTHUOC thuộc HSBA mình phụ trách.
--    - Chỉ thấy BENHNHAN có HSBA do mình phụ trách.
--    - Chỉ được cập nhật TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC của bệnh nhân đó.
-- =====================================================================

CREATE OR REPLACE PACKAGE ADMINHOS.PKG_VPD_YC1C3 AS

    -- ================================================================
    -- Policy cho Điều phối viên
    -- ================================================================
    FUNCTION FN_BENHNHAN_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;

    FUNCTION FN_HSBA_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;

    FUNCTION FN_HSBADV_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;


    -- ================================================================
    -- Policy cho Bác sĩ/Y sĩ
    -- ================================================================
    FUNCTION FN_HSBA_BS(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;

    FUNCTION FN_HSBADV_BS(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;

    FUNCTION FN_DONTHUOC_BS(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;

    FUNCTION FN_BENHNHAN_BS(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;

END PKG_VPD_YC1C3;
/

SHOW ERRORS PACKAGE ADMINHOS.PKG_VPD_YC1C3;


CREATE OR REPLACE PACKAGE BODY ADMINHOS.PKG_VPD_YC1C3 AS

    -- ================================================================
    -- Hàm kiểm tra user hiện tại có phải Điều phối viên không
    -- ================================================================
    FUNCTION IS_DPV RETURN BOOLEAN AS
        v_count NUMBER;
    BEGIN
        SELECT COUNT(*)
        INTO v_count
        FROM ADMINHOS.NHANVIEN
        WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')
          AND VAITRO = N'Điều phối viên';

        RETURN v_count > 0;
    EXCEPTION
        WHEN OTHERS THEN
            RETURN FALSE;
    END IS_DPV;


    -- ================================================================
    -- Hàm kiểm tra user hiện tại có phải Bác sĩ/Y sĩ không
    -- ================================================================
    FUNCTION IS_BS RETURN BOOLEAN AS
        v_count NUMBER;
    BEGIN
        SELECT COUNT(*)
        INTO v_count
        FROM ADMINHOS.NHANVIEN
        WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')
          AND VAITRO = N'Bác sĩ/Y sĩ';

        RETURN v_count > 0;
    EXCEPTION
        WHEN OTHERS THEN
            RETURN FALSE;
    END IS_BS;


    -- ================================================================
    -- 1. POLICY CHO ĐIỀU PHỐI VIÊN
    -- ================================================================

    FUNCTION FN_BENHNHAN_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_DPV THEN
            -- Điều phối viên được xem/thêm/sửa toàn bộ bệnh nhân
            RETURN '1 = 1';
        END IF;

        -- Không phải Điều phối viên thì policy này không ảnh hưởng
        RETURN NULL;
    END FN_BENHNHAN_DPV;


    FUNCTION FN_HSBA_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_DPV THEN
            -- Điều phối viên chỉ thấy HSBA của bác sĩ cùng cơ sở hoặc chưa chỉ định bác sĩ
            RETURN 'MABS IS NULL OR MABS IN (
                SELECT NV.MANV
                FROM ADMINHOS.NHANVIEN NV
                WHERE NV.COSO = (
                    SELECT DP.COSO
                    FROM ADMINHOS.NHANVIEN DP
                    WHERE DP.MANV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                      AND DP.VAITRO = N''Điều phối viên''
                )
            )';
        END IF;

        RETURN NULL;
    END FN_HSBA_DPV;


    FUNCTION FN_HSBADV_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_DPV THEN
            -- Điều phối viên được xem toàn bộ HSBA_DV
            -- và cập nhật MAKTV để điều phối KTV
            RETURN '1 = 1';
        END IF;

        RETURN NULL;
    END FN_HSBADV_DPV;


    -- ================================================================
    -- 2. POLICY CHO BÁC SĨ/Y SĨ
    -- ================================================================

    FUNCTION FN_HSBA_BS(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_BS THEN
            -- Bác sĩ/Y sĩ chỉ thấy HSBA do chính mình phụ trách
            RETURN 'MABS = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
        END IF;

        RETURN NULL;
    END FN_HSBA_BS;


    FUNCTION FN_HSBADV_BS(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_BS THEN
            -- Chỉ thấy/thêm/xóa dịch vụ thuộc HSBA mình phụ trách
            RETURN 'MAHSBA IN (
                        SELECT H.MAHSBA
                        FROM ADMINHOS.HSBA H
                        WHERE H.MABS = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                    )';
        END IF;

        RETURN NULL;
    END FN_HSBADV_BS;


    FUNCTION FN_DONTHUOC_BS(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_BS THEN
            -- Chỉ thấy/thêm/sửa/xóa đơn thuốc thuộc HSBA mình phụ trách
            RETURN 'MAHSBA IN (
                        SELECT H.MAHSBA
                        FROM ADMINHOS.HSBA H
                        WHERE H.MABS = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                    )';
        END IF;

        RETURN NULL;
    END FN_DONTHUOC_BS;


    FUNCTION FN_BENHNHAN_BS(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_BS THEN
            -- Chỉ thấy bệnh nhân có HSBA do mình phụ trách
            RETURN 'MABN IN (
                        SELECT H.MABN
                        FROM ADMINHOS.HSBA H
                        WHERE H.MABS = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                    )';
        END IF;

        RETURN NULL;
    END FN_BENHNHAN_BS;

END PKG_VPD_YC1C3;
/

SHOW ERRORS PACKAGE BODY ADMINHOS.PKG_VPD_YC1C3;


-- =====================================================================
-- PHẦN 3. ĐĂNG KÝ CÁC POLICY VPD
-- =====================================================================

-- ---------------------------------------------------------------------
-- 3.1. Policy cho Điều phối viên trên BENHNHAN
--      Điều phối viên được SELECT, INSERT, UPDATE toàn bộ BENHNHAN.
--      Không cấp DELETE vì đề không yêu cầu xóa bệnh nhân.
-- ---------------------------------------------------------------------
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'BENHNHAN',
        policy_name     => 'VPD_YC1C3_BENHNHAN_DPV',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_BENHNHAN_DPV',
        statement_types => 'SELECT, INSERT, UPDATE',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('OK: Da tao policy VPD_YC1C3_BENHNHAN_DPV');
END;
/


-- ---------------------------------------------------------------------
-- 3.2. Policy cho Điều phối viên trên HSBA
--      Điều phối viên được SELECT, INSERT HSBA,
--      và UPDATE cột MAKHOA, MABS.
-- ---------------------------------------------------------------------
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'HSBA',
        policy_name     => 'VPD_YC1C3_HSBA_DPV',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_HSBA_DPV',
        statement_types => 'SELECT, INSERT, UPDATE',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('OK: Da tao policy VPD_YC1C3_HSBA_DPV');
END;
/


-- ---------------------------------------------------------------------
-- 3.3. Policy cho Điều phối viên trên HSBA_DV
--      Điều phối viên được SELECT HSBA_DV,
--      và UPDATE cột MAKTV để điều phối kỹ thuật viên.
--      Không cấp INSERT/DELETE vì việc thêm/xóa dịch vụ là của Bác sĩ/Y sĩ.
-- ---------------------------------------------------------------------
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'HSBA_DV',
        policy_name     => 'VPD_YC1C3_HSBADV_DPV',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_HSBADV_DPV',
        statement_types => 'SELECT, UPDATE',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('OK: Da tao policy VPD_YC1C3_HSBADV_DPV');
END;
/


-- ---------------------------------------------------------------------
-- 3.4. Policy cho Bác sĩ/Y sĩ trên HSBA
--      Chỉ thấy/cập nhật HSBA mà MABS = user hiện tại.
-- ---------------------------------------------------------------------
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'HSBA',
        policy_name     => 'VPD_YC1C3_HSBA_BS',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_HSBA_BS',
        statement_types => 'SELECT, UPDATE',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('OK: Da tao policy VPD_YC1C3_HSBA_BS');
END;
/


-- ---------------------------------------------------------------------
-- 3.5. Policy cho Bác sĩ/Y sĩ trên HSBA_DV
--      Chỉ thấy/thêm/xóa HSBA_DV thuộc HSBA mình phụ trách.
-- ---------------------------------------------------------------------
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'HSBA_DV',
        policy_name     => 'VPD_YC1C3_HSBADV_BS',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_HSBADV_BS',
        statement_types => 'SELECT, INSERT, DELETE',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('OK: Da tao policy VPD_YC1C3_HSBADV_BS');
END;
/


-- ---------------------------------------------------------------------
-- 3.6. Policy cho Bác sĩ/Y sĩ trên DONTHUOC
--      Chỉ thấy/thêm/sửa/xóa đơn thuốc thuộc HSBA mình phụ trách.
-- ---------------------------------------------------------------------
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'DONTHUOC',
        policy_name     => 'VPD_YC1C3_DONTHUOC_BS',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_DONTHUOC_BS',
        statement_types => 'SELECT, INSERT, UPDATE, DELETE',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('OK: Da tao policy VPD_YC1C3_DONTHUOC_BS');
END;
/


-- ---------------------------------------------------------------------
-- 3.7. Policy cho Bác sĩ/Y sĩ trên BENHNHAN
--      Chỉ thấy/cập nhật bệnh nhân có HSBA do mình phụ trách.
-- ---------------------------------------------------------------------
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'BENHNHAN',
        policy_name     => 'VPD_YC1C3_BENHNHAN_BS',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_BENHNHAN_BS',
        statement_types => 'SELECT, UPDATE',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('OK: Da tao policy VPD_YC1C3_BENHNHAN_BS');
END;
/


-- =====================================================================
-- PHẦN 4. DỌN CÁC QUYỀN SAI/DƯ NẾU TRƯỚC ĐÓ ĐÃ CHẠY SCRIPT CŨ
-- =====================================================================
-- Mục tiêu:
--   - Tránh trường hợp ROLE_NHANVIEN bị cấp quyền trực tiếp trên bảng gốc.
--   - Tránh trường hợp DP/BS còn dư quyền do script cũ cấp nhầm.
-- =====================================================================

CREATE OR REPLACE PROCEDURE ADMINHOS.SP_YC1C3_SAFE_REVOKE AS

    PROCEDURE TRY_REVOKE(
        p_sql IN VARCHAR2
    ) AS
    BEGIN
        EXECUTE IMMEDIATE p_sql;
    EXCEPTION
        WHEN OTHERS THEN
            NULL;
    END TRY_REVOKE;

BEGIN
    -- ------------------------------------------------------------
    -- Dọn quyền nguy hiểm nếu trước đó lỡ grant bảng gốc cho role
    -- ------------------------------------------------------------
    TRY_REVOKE('REVOKE SELECT ON ADMINHOS.BENHNHAN FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE INSERT ON ADMINHOS.BENHNHAN FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE UPDATE ON ADMINHOS.BENHNHAN FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE DELETE ON ADMINHOS.BENHNHAN FROM ROLE_NHANVIEN');

    TRY_REVOKE('REVOKE SELECT ON ADMINHOS.HSBA FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE INSERT ON ADMINHOS.HSBA FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE UPDATE ON ADMINHOS.HSBA FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE DELETE ON ADMINHOS.HSBA FROM ROLE_NHANVIEN');

    TRY_REVOKE('REVOKE SELECT ON ADMINHOS.HSBA_DV FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE INSERT ON ADMINHOS.HSBA_DV FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE UPDATE ON ADMINHOS.HSBA_DV FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE DELETE ON ADMINHOS.HSBA_DV FROM ROLE_NHANVIEN');

    TRY_REVOKE('REVOKE SELECT ON ADMINHOS.DONTHUOC FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE INSERT ON ADMINHOS.DONTHUOC FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE UPDATE ON ADMINHOS.DONTHUOC FROM ROLE_NHANVIEN');
    TRY_REVOKE('REVOKE DELETE ON ADMINHOS.DONTHUOC FROM ROLE_NHANVIEN');


    -- ------------------------------------------------------------
    -- Dọn quyền trực tiếp cũ của Điều phối viên và Bác sĩ/Y sĩ
    -- Sau đó phần 5 sẽ grant lại đúng quyền.
    -- ------------------------------------------------------------
    FOR r IN (
        SELECT MANV
        FROM ADMINHOS.NHANVIEN
        WHERE VAITRO IN (N'Điều phối viên', N'Bác sĩ/Y sĩ')
    ) LOOP
        -- BENHNHAN
        TRY_REVOKE('REVOKE SELECT ON ADMINHOS.BENHNHAN FROM ' || r.MANV);
        TRY_REVOKE('REVOKE INSERT ON ADMINHOS.BENHNHAN FROM ' || r.MANV);
        TRY_REVOKE('REVOKE UPDATE ON ADMINHOS.BENHNHAN FROM ' || r.MANV);
        TRY_REVOKE('REVOKE DELETE ON ADMINHOS.BENHNHAN FROM ' || r.MANV);

        -- HSBA
        TRY_REVOKE('REVOKE SELECT ON ADMINHOS.HSBA FROM ' || r.MANV);
        TRY_REVOKE('REVOKE INSERT ON ADMINHOS.HSBA FROM ' || r.MANV);
        TRY_REVOKE('REVOKE UPDATE ON ADMINHOS.HSBA FROM ' || r.MANV);
        TRY_REVOKE('REVOKE DELETE ON ADMINHOS.HSBA FROM ' || r.MANV);

        -- HSBA_DV
        TRY_REVOKE('REVOKE SELECT ON ADMINHOS.HSBA_DV FROM ' || r.MANV);
        TRY_REVOKE('REVOKE INSERT ON ADMINHOS.HSBA_DV FROM ' || r.MANV);
        TRY_REVOKE('REVOKE UPDATE ON ADMINHOS.HSBA_DV FROM ' || r.MANV);
        TRY_REVOKE('REVOKE DELETE ON ADMINHOS.HSBA_DV FROM ' || r.MANV);

        -- DONTHUOC
        TRY_REVOKE('REVOKE SELECT ON ADMINHOS.DONTHUOC FROM ' || r.MANV);
        TRY_REVOKE('REVOKE INSERT ON ADMINHOS.DONTHUOC FROM ' || r.MANV);
        TRY_REVOKE('REVOKE UPDATE ON ADMINHOS.DONTHUOC FROM ' || r.MANV);
        TRY_REVOKE('REVOKE DELETE ON ADMINHOS.DONTHUOC FROM ' || r.MANV);
    END LOOP;

    DBMS_OUTPUT.PUT_LINE('OK: Da don cac quyen cu/sai cua YC1 Cau 3.');
END;
/

SHOW ERRORS PROCEDURE ADMINHOS.SP_YC1C3_SAFE_REVOKE;

EXEC ADMINHOS.SP_YC1C3_SAFE_REVOKE;


-- =====================================================================
-- PHẦN 5. CẤP QUYỀN ĐỐI TƯỢNG ĐÚNG CHO ĐIỀU PHỐI VIÊN
-- =====================================================================

-- View cho Điều phối viên xem danh sách Bác sĩ/Y sĩ và Kỹ thuật viên
-- Chỉ hiển thị các cột cần thiết để phân công:
-- MANV, HOTEN, CHUYENKHOA, VAITRO
-- Không cho xem CMND, ngày sinh, quê quán, số điện thoại...
CREATE OR REPLACE VIEW ADMINHOS.VW_NHANVIEN_DIEUPHOI AS
SELECT 
    NV.MANV,
    NV.HOTEN,
    NV.CHUYENKHOA,
    NV.VAITRO,
    NV.COSO
FROM ADMINHOS.NHANVIEN NV
WHERE NV.VAITRO IN (N'Bác sĩ/Y sĩ', N'Kỹ thuật viên')
  AND (
        NV.COSO = (
            SELECT DP.COSO
            FROM ADMINHOS.NHANVIEN DP
            WHERE DP.MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')
              AND DP.VAITRO = N'Điều phối viên'
        )
        OR NOT EXISTS (
            SELECT 1
            FROM ADMINHOS.NHANVIEN DP
            WHERE DP.MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')
              AND DP.VAITRO = N'Điều phối viên'
        )
  );
/

CREATE OR REPLACE PROCEDURE ADMINHOS.SP_YC1C3_GRANT_DPV AS
BEGIN
    FOR r IN (
        SELECT MANV
        FROM ADMINHOS.NHANVIEN
        WHERE VAITRO = N'Điều phối viên'
    ) LOOP

        -- ------------------------------------------------------------
        -- BENHNHAN:
        -- Điều phối viên được xem, thêm, sửa dữ liệu bệnh nhân.
        -- Không cấp DELETE vì đề không yêu cầu xóa bệnh nhân.
        -- ------------------------------------------------------------
        EXECUTE IMMEDIATE
            'GRANT SELECT, INSERT ON ADMINHOS.BENHNHAN TO ' || r.MANV;

        EXECUTE IMMEDIATE
            'GRANT UPDATE ON ADMINHOS.BENHNHAN TO ' || r.MANV;


        -- ------------------------------------------------------------
        -- HSBA:
        -- Điều phối viên được xem, tạo mới HSBA.
        -- Chỉ được cập nhật MAKHOA và MABS để điều phối khoa/bác sĩ.
        -- ------------------------------------------------------------
        EXECUTE IMMEDIATE
            'GRANT SELECT, INSERT ON ADMINHOS.HSBA TO ' || r.MANV;

        EXECUTE IMMEDIATE
            'GRANT UPDATE (MAKHOA, MABS) ON ADMINHOS.HSBA TO ' || r.MANV;


        -- ------------------------------------------------------------
        -- HSBA_DV:
        -- Điều phối viên được xem dịch vụ.
        -- Chỉ được cập nhật MAKTV để điều phối kỹ thuật viên.
        -- Không cấp INSERT/DELETE vì thêm/xóa dịch vụ là quyền của Bác sĩ/Y sĩ.
        -- ------------------------------------------------------------
        EXECUTE IMMEDIATE
            'GRANT SELECT ON ADMINHOS.HSBA_DV TO ' || r.MANV;

        EXECUTE IMMEDIATE
            'GRANT UPDATE (MAKTV) ON ADMINHOS.HSBA_DV TO ' || r.MANV;


        -- ------------------------------------------------------------
        -- VW_NHANVIEN_DIEUPHOI:
        -- Điều phối viên được xem mã nhân viên, họ tên, chuyên khoa, vai trò
        -- của Bác sĩ/Y sĩ và Kỹ thuật viên để phục vụ phân công.
        -- Không cấp SELECT trực tiếp trên bảng NHANVIEN để tránh lộ thông tin nhạy cảm.
        -- ------------------------------------------------------------
        EXECUTE IMMEDIATE
            'GRANT SELECT ON ADMINHOS.VW_NHANVIEN_DIEUPHOI TO ' || r.MANV;

    END LOOP;

    DBMS_OUTPUT.PUT_LINE('OK: Da cap quyen dung cho Dieu phoi vien.');
END;
/

SHOW ERRORS PROCEDURE ADMINHOS.SP_YC1C3_GRANT_DPV;

EXEC ADMINHOS.SP_YC1C3_GRANT_DPV;


-- =====================================================================
-- PHẦN 6. CẤP QUYỀN ĐỐI TƯỢNG ĐÚNG CHO BÁC SĨ/Y SĨ
-- =====================================================================

CREATE OR REPLACE PROCEDURE ADMINHOS.SP_YC1C3_GRANT_BS AS
BEGIN
    FOR r IN (
        SELECT MANV
        FROM ADMINHOS.NHANVIEN
        WHERE VAITRO = N'Bác sĩ/Y sĩ'
    ) LOOP

        -- ------------------------------------------------------------
        -- HSBA:
        -- Bác sĩ/Y sĩ được xem HSBA do mình phụ trách.
        -- Được cập nhật CHANDOAN, DIEUTRI, KETLUAN.
        -- VPD sẽ lọc theo MABS = user hiện tại.
        -- ------------------------------------------------------------
        EXECUTE IMMEDIATE
            'GRANT SELECT ON ADMINHOS.HSBA TO ' || r.MANV;

        EXECUTE IMMEDIATE
            'GRANT UPDATE (CHANDOAN, DIEUTRI, KETLUAN) ON ADMINHOS.HSBA TO ' || r.MANV;


        -- ------------------------------------------------------------
        -- HSBA_DV:
        -- Bác sĩ/Y sĩ được xem, thêm, xóa dịch vụ thuộc HSBA mình phụ trách.
        -- Không cấp UPDATE vì đề không yêu cầu bác sĩ sửa HSBA_DV.
        -- ------------------------------------------------------------
        EXECUTE IMMEDIATE
            'GRANT SELECT, INSERT, DELETE ON ADMINHOS.HSBA_DV TO ' || r.MANV;


        -- ------------------------------------------------------------
        -- DONTHUOC:
        -- Bác sĩ/Y sĩ được xem, thêm, sửa, xóa đơn thuốc thuộc HSBA mình phụ trách.
        -- VPD sẽ chặn thao tác trên HSBA không phải của mình.
        -- ------------------------------------------------------------
        EXECUTE IMMEDIATE
            'GRANT SELECT, INSERT, UPDATE, DELETE ON ADMINHOS.DONTHUOC TO ' || r.MANV;


        -- ------------------------------------------------------------
        -- BENHNHAN:
        -- Bác sĩ/Y sĩ được xem bệnh nhân liên quan đến HSBA mình phụ trách.
        -- Chỉ được cập nhật tiền sử bệnh, tiền sử bệnh gia đình, dị ứng thuốc.
        -- ------------------------------------------------------------
        EXECUTE IMMEDIATE
            'GRANT SELECT ON ADMINHOS.BENHNHAN TO ' || r.MANV;

        EXECUTE IMMEDIATE
            'GRANT UPDATE (TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC) ON ADMINHOS.BENHNHAN TO '
            || r.MANV;

    END LOOP;

    DBMS_OUTPUT.PUT_LINE('OK: Da cap quyen dung cho Bac si/Y si.');
END;
/

SHOW ERRORS PROCEDURE ADMINHOS.SP_YC1C3_GRANT_BS;

EXEC ADMINHOS.SP_YC1C3_GRANT_BS;


-- =====================================================================
-- PHẦN 7. KIỂM TRA POLICY VÀ QUYỀN ĐÃ CẤP
-- =====================================================================

PROMPT
PROMPT ===== DANH SACH VPD POLICY YC1 CAU 3 =====

COLUMN OBJECT_OWNER FORMAT A12;
COLUMN OBJECT_NAME FORMAT A15;
COLUMN POLICY_NAME FORMAT A30;
COLUMN FUNCTION FORMAT A45;

SELECT
    OBJECT_OWNER,
    OBJECT_NAME,
    POLICY_NAME,
    FUNCTION,
    SEL,
    INS,
    UPD,
    DEL,
    ENABLE
FROM DBA_POLICIES
WHERE OBJECT_OWNER = 'ADMINHOS'
  AND OBJECT_NAME IN ('BENHNHAN', 'HSBA', 'HSBA_DV', 'DONTHUOC')
  AND POLICY_NAME LIKE 'VPD_YC1C3%'
ORDER BY OBJECT_NAME, POLICY_NAME;


PROMPT
PROMPT ===== QUYEN OBJECT CUA DP0001 / BS0001 / KTV001 DE CHECK NHANH =====

COLUMN GRANTEE FORMAT A15;
COLUMN OWNER FORMAT A10;
COLUMN TABLE_NAME FORMAT A15;
COLUMN PRIVILEGE FORMAT A15;

SELECT GRANTEE, OWNER, TABLE_NAME, PRIVILEGE
FROM DBA_TAB_PRIVS
WHERE OWNER = 'ADMINHOS'
  AND GRANTEE IN ('DP0001', 'BS0001', 'KTV001', 'ROLE_NHANVIEN')
  AND TABLE_NAME IN ('BENHNHAN', 'HSBA', 'HSBA_DV', 'DONTHUOC')
ORDER BY GRANTEE, TABLE_NAME, PRIVILEGE;


PROMPT
PROMPT ===== QUYEN COT CUA DP0001 / BS0001 =====

COLUMN GRANTEE FORMAT A15;
COLUMN OWNER FORMAT A10;
COLUMN TABLE_NAME FORMAT A15;
COLUMN COLUMN_NAME FORMAT A20;
COLUMN PRIVILEGE FORMAT A15;

SELECT GRANTEE, OWNER, TABLE_NAME, COLUMN_NAME, PRIVILEGE
FROM DBA_COL_PRIVS
WHERE OWNER = 'ADMINHOS'
  AND GRANTEE IN ('DP0001', 'BS0001')
  AND TABLE_NAME IN ('BENHNHAN', 'HSBA', 'HSBA_DV', 'DONTHUOC')
ORDER BY GRANTEE, TABLE_NAME, COLUMN_NAME, PRIVILEGE;


PROMPT
PROMPT =====================================================================
PROMPT HOAN TAT SCRIPT YC1 CAU 3 - VPD CHO DPV VA BS/YSI
PROMPT =====================================================================


-- =====================================================================
-- PHẦN 8. TEST MẪU
-- =====================================================================
-- Các lệnh dưới đây để bạn copy chạy riêng từng user.
-- Không chạy nguyên khối nếu chưa hiểu vì có CONNECT nhiều user.
-- =====================================================================


-- =====================================================================
-- TEST A. ĐIỀU PHỐI VIÊN DP0001
-- =====================================================================

-- CONNECT DP0001/"Hos@123456"@localhost:1521/PDBHOSX
--
-- SHOW USER;
--
-- -- A1. DP xem toàn bộ bệnh nhân
-- SELECT COUNT(*) AS SO_BENHNHAN_DPV
-- FROM ADMINHOS.BENHNHAN;
--
-- -- A2. DP xem toàn bộ HSBA
-- SELECT COUNT(*) AS SO_HSBA_DPV
-- FROM ADMINHOS.HSBA;
--
-- -- A3. DP xem toàn bộ HSBA_DV
-- SELECT COUNT(*) AS SO_HSBADV_DPV
-- FROM ADMINHOS.HSBA_DV;
--
-- -- A4. DP được sửa thông tin bệnh nhân
-- UPDATE ADMINHOS.BENHNHAN
-- SET TENDUONG = N'Duong test DP0001'
-- WHERE MABN = 'BN000001';
--
-- ROLLBACK;
--
-- -- A5. DP được thêm HSBA mới
-- INSERT INTO ADMINHOS.HSBA (
--     MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN
-- )
-- VALUES (
--     'HSDPTEST1',
--     'BN000001',
--     SYSDATE,
--     NULL,
--     NULL,
--     'BS0001',
--     'KTM',
--     NULL
-- );
--
-- ROLLBACK;
--
-- -- A6. DP được cập nhật MABS, MAKHOA trên HSBA
-- UPDATE ADMINHOS.HSBA
-- SET MABS = 'BS0002',
--     MAKHOA = 'KTK'
-- WHERE MAHSBA = 'HSBA00001';
--
-- ROLLBACK;
--
-- -- A7. DP KHÔNG được cập nhật CHANDOAN
-- -- Kỳ vọng lỗi: ORA-01031 insufficient privileges
-- UPDATE ADMINHOS.HSBA
-- SET CHANDOAN = N'DP khong duoc sua chan doan'
-- WHERE MAHSBA = 'HSBA00001';
--
-- -- A8. DP được cập nhật MAKTV trên HSBA_DV
-- UPDATE ADMINHOS.HSBA_DV
-- SET MAKTV = 'KTV002'
-- WHERE MAHSBA = 'HSBA00001';
--
-- ROLLBACK;
--
-- -- A9. DP KHÔNG được xóa HSBA_DV
-- -- Kỳ vọng lỗi: ORA-01031 insufficient privileges
-- DELETE FROM ADMINHOS.HSBA_DV
-- WHERE MAHSBA = 'HSBA00001';


-- =====================================================================
-- TEST B. BÁC SĨ/Y SĨ BS0001
-- =====================================================================

-- CONNECT BS0001/"Hos@123456"@localhost:1521/PDBHOSX
--
-- SHOW USER;
--
-- -- B1. BS chỉ thấy HSBA do mình phụ trách
-- SELECT MAHSBA, MABN, MABS, MAKHOA
-- FROM ADMINHOS.HSBA
-- ORDER BY MAHSBA;
--
-- -- B2. BS không thấy HSBA của bác sĩ khác
-- -- Nếu HSBA00002 thuộc BS0002 thì kỳ vọng 0 dòng
-- SELECT *
-- FROM ADMINHOS.HSBA
-- WHERE MAHSBA = 'HSBA00002';
--
-- -- B3. BS được cập nhật CHANDOAN, DIEUTRI, KETLUAN trên HSBA mình phụ trách
-- UPDATE ADMINHOS.HSBA
-- SET CHANDOAN = N'Chan doan test BS0001',
--     DIEUTRI  = N'Dieu tri test BS0001',
--     KETLUAN  = N'Ket luan test BS0001'
-- WHERE MAHSBA = 'HSBA00001';
--
-- ROLLBACK;
--
-- -- B4. BS KHÔNG được đổi MABS
-- -- Kỳ vọng lỗi: ORA-01031 insufficient privileges
-- UPDATE ADMINHOS.HSBA
-- SET MABS = 'BS0002'
-- WHERE MAHSBA = 'HSBA00001';
--
-- -- B5. BS chỉ thấy bệnh nhân liên quan đến HSBA mình phụ trách
-- SELECT MABN, TENBN, TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC
-- FROM ADMINHOS.BENHNHAN
-- ORDER BY MABN;
--
-- -- B6. BS được cập nhật tiền sử bệnh của bệnh nhân mình điều trị
-- UPDATE ADMINHOS.BENHNHAN
-- SET TIENSUBENH = N'Tien su benh test BS0001'
-- WHERE MABN = 'BN000001';
--
-- ROLLBACK;
--
-- -- B7. BS KHÔNG được sửa tên bệnh nhân
-- -- Kỳ vọng lỗi: ORA-01031 insufficient privileges
-- UPDATE ADMINHOS.BENHNHAN
-- SET TENBN = N'Ten sai quyen'
-- WHERE MABN = 'BN000001';
--
-- -- B8. BS được thêm dịch vụ cho HSBA mình phụ trách
-- INSERT INTO ADMINHOS.HSBA_DV (
--     MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA
-- )
-- VALUES (
--     'HSBA00001',
--     N'Dich vu test BS0001',
--     SYSDATE,
--     NULL,
--     NULL
-- );
--
-- ROLLBACK;
--
-- -- B9. BS KHÔNG được thêm dịch vụ cho HSBA của bác sĩ khác
-- -- Nếu HSBA00002 thuộc BS0002 thì kỳ vọng lỗi ORA-28115 hoặc không thỏa policy
-- INSERT INTO ADMINHOS.HSBA_DV (
--     MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA
-- )
-- VALUES (
--     'HSBA00002',
--     N'Dich vu sai quyen',
--     SYSDATE,
--     NULL,
--     NULL
-- );
--
-- -- B10. BS được thao tác đơn thuốc thuộc HSBA mình phụ trách
-- INSERT INTO ADMINHOS.DONTHUOC (
--     MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
-- )
-- VALUES (
--     'HSBA00001',
--     SYSDATE,
--     N'Thuoc test BS0001',
--     N'Uong 1 vien/ngay'
-- );
--
-- ROLLBACK;
--
-- -- B11. BS KHÔNG được thêm đơn thuốc cho HSBA của bác sĩ khác
-- -- Nếu HSBA00002 thuộc BS0002 thì kỳ vọng lỗi ORA-28115 hoặc không thỏa policy
-- INSERT INTO ADMINHOS.DONTHUOC (
--     MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
-- )
-- VALUES (
--     'HSBA00002',
--     SYSDATE,
--     N'Thuoc sai quyen',
--     N'Uong 1 vien/ngay'
-- );


-- =====================================================================
-- TEST C. KỸ THUẬT VIÊN KTV001 KHÔNG ĐƯỢC LỘ BẢNG GỐC
-- =====================================================================

-- CONNECT KTV001/"Hos@123456"@localhost:1521/PDBHOSX
--
-- SHOW USER;
--
-- -- C1. KTV không được SELECT trực tiếp bảng BENHNHAN
-- -- Kỳ vọng lỗi: ORA-00942 hoặc ORA-01031
-- SELECT COUNT(*)
-- FROM ADMINHOS.BENHNHAN;
--
-- -- C2. KTV chỉ thao tác qua view của YC1 Câu 2
-- SELECT *
-- FROM ADMINHOS.VW_HSBA_DV_KTV;

-- =====================================================================
-- PHÂN HỆ 2 - YÊU CẦU 2
-- CƠ CHẾ PHÁT TÁN THÔNG BÁO DÙNG ORACLE LABEL SECURITY
-- Schema: ADMINHOS
-- PDB: PDBHOSX
-- BẢN CUỐI: KHÔNG DÙNG PUBLIC SYNONYM, KHÔNG CỘT GHICHU
-- =====================================================================

SET SERVEROUTPUT ON;

-- =====================================================================
-- PHẦN 1. CHẠY BẰNG SYS AS SYSDBA
-- Mục đích:
-- 1. Chuyển vào PDBHOSX
-- 2. Dọn sạch các object/policy/role cũ
-- 3. Cấp quyền cần thiết cho ADMINHOS
-- =====================================================================

CONNECT SYS AS SYSDBA;

ALTER SESSION SET CONTAINER = PDBHOSX;

-- Kiểm tra Oracle Label Security
SELECT VALUE
FROM V$OPTION
WHERE PARAMETER = 'Oracle Label Security';

SELECT COMP_NAME, STATUS
FROM DBA_REGISTRY
WHERE COMP_ID = 'OLS';


-- Mở khóa LBACSYS nếu đang bị khóa
BEGIN
    EXECUTE IMMEDIATE 'ALTER USER LBACSYS ACCOUNT UNLOCK';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


-- Dọn public synonym cũ nếu trước đó đã lỡ tạo
BEGIN
    EXECUTE IMMEDIATE 'DROP PUBLIC SYNONYM THONGBAO';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP PUBLIC SYNONYM VW_THONGBAO_APP';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


-- Gỡ policy khỏi bảng nếu policy đã từng apply vào bảng THONGBAO
BEGIN
    SA_POLICY_ADMIN.REMOVE_TABLE_POLICY(
        policy_name => 'THONGBAO_OLS',
        schema_name => 'ADMINHOS',
        table_name  => 'THONGBAO',
        drop_column => TRUE
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


CONNECT adminHos/123@localhost:1521/PDBHOSX

-- Xóa view cũ nếu tồn tại
BEGIN
    EXECUTE IMMEDIATE 'DROP VIEW ADMINHOS.VW_THONGBAO_APP';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


-- Xóa bảng cũ nếu tồn tại
BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE ADMINHOS.THONGBAO CASCADE CONSTRAINTS PURGE';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


-- Xóa policy cũ nếu tồn tại
BEGIN
    SA_SYSDBA.DROP_POLICY(
        policy_name => 'THONGBAO_OLS',
        drop_column => TRUE
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


-- Xóa role policy cũ nếu còn sót lại
BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE THONGBAO_OLS_DBA';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


-- Xóa user demo cũ nếu tồn tại
BEGIN
    FOR r IN (
        SELECT USERNAME
        FROM DBA_USERS
        WHERE USERNAME IN ('U1','U2','U3','U4','U5','U6','U7','U8')
    )
    LOOP
        EXECUTE IMMEDIATE 'DROP USER ' || r.USERNAME || ' CASCADE';
    END LOOP;
END;
/


CONNECT SYS AS SYSDBA;
ALTER SESSION SET CONTAINER = PDBHOSX;

-- Cấp quyền dùng các package OLS cho ADMINHOS
GRANT EXECUTE ON LBACSYS.SA_SYSDBA TO ADMINHOS;
GRANT EXECUTE ON LBACSYS.SA_COMPONENTS TO ADMINHOS;
GRANT EXECUTE ON LBACSYS.SA_LABEL_ADMIN TO ADMINHOS;
GRANT EXECUTE ON SA_POLICY_ADMIN TO ADMINHOS;
GRANT EXECUTE ON LBACSYS.SA_USER_ADMIN TO ADMINHOS;

-- Quyền quản trị Label Security
GRANT LBAC_DBA TO ADMINHOS;

-- =====================================================================
-- PHẦN 2. CHẠY BẰNG ADMINHOS
-- Tạo bảng THONGBAO và tạo OLS policy
-- =====================================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- Tạo bảng THONGBAO
-- Lưu ý:
-- Không tạo cột OLS_LABEL thủ công.
-- Cột OLS_LABEL sẽ được Oracle tự thêm sau khi APPLY_TABLE_POLICY thành công.
CREATE TABLE THONGBAO (
    MATB        VARCHAR2(10) PRIMARY KEY,
    NOIDUNG     NVARCHAR2(500) NOT NULL,
    NGAYGIO     TIMESTAMP DEFAULT SYSTIMESTAMP NOT NULL,
    DIADIEM     NVARCHAR2(100)
);


-- Tạo OLS policy
BEGIN
    SA_SYSDBA.CREATE_POLICY(
        policy_name     => 'THONGBAO_OLS',
        column_name     => 'OLS_LABEL',
        default_options => 'READ_CONTROL,WRITE_CONTROL,CHECK_CONTROL'
    );

    DBMS_OUTPUT.PUT_LINE('Da tao policy THONGBAO_OLS.');
END;
/


-- =====================================================================
-- PHẦN 3. QUAY LẠI SYSDBA
-- Cấp role quản trị riêng của policy cho ADMINHOS
-- =====================================================================

CONNECT SYS AS SYSDBA;

ALTER SESSION SET CONTAINER = PDBHOSX;

-- Sau khi CREATE_POLICY, Oracle tạo role THONGBAO_OLS_DBA
-- Cấp role này cho ADMINHOS để tránh lỗi ORA-12407
GRANT THONGBAO_OLS_DBA TO ADMINHOS;


-- =====================================================================
-- PHẦN 4. QUAY LẠI ADMINHOS
-- Bật role policy và tạo LEVEL / COMPARTMENT / GROUP
-- =====================================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- Bật quyền quản trị policy trong session hiện tại
SET ROLE THONGBAO_OLS_DBA;


-- ---------------------------------------------------------------------
-- 4.1. TẠO LEVEL
-- Ban Giám đốc > Lãnh đạo khoa > Nhân viên
-- ---------------------------------------------------------------------
BEGIN
    SA_COMPONENTS.CREATE_LEVEL(
        policy_name => 'THONGBAO_OLS',
        level_num   => 10,
        short_name  => 'NV',
        long_name   => 'Nhan vien'
    );

    SA_COMPONENTS.CREATE_LEVEL(
        policy_name => 'THONGBAO_OLS',
        level_num   => 20,
        short_name  => 'LDK',
        long_name   => 'Lanh dao khoa'
    );

    SA_COMPONENTS.CREATE_LEVEL(
        policy_name => 'THONGBAO_OLS',
        level_num   => 30,
        short_name  => 'BGD',
        long_name   => 'Ban giam doc'
    );

    DBMS_OUTPUT.PUT_LINE('Da tao LEVEL: NV, LDK, BGD.');
END;
/


-- ---------------------------------------------------------------------
-- 4.2. TẠO COMPARTMENT - KHOA
-- ---------------------------------------------------------------------
BEGIN
    SA_COMPONENTS.CREATE_COMPARTMENT(
        policy_name => 'THONGBAO_OLS',
        comp_num    => 10,
        short_name  => 'TH',
        long_name   => 'Khoa tieu hoa'
    );

    SA_COMPONENTS.CREATE_COMPARTMENT(
        policy_name => 'THONGBAO_OLS',
        comp_num    => 20,
        short_name  => 'TK',
        long_name   => 'Khoa than kinh'
    );

    SA_COMPONENTS.CREATE_COMPARTMENT(
        policy_name => 'THONGBAO_OLS',
        comp_num    => 30,
        short_name  => 'TM',
        long_name   => 'Khoa tim mach'
    );

    DBMS_OUTPUT.PUT_LINE('Da tao COMPARTMENT: TH, TK, TM.');
END;
/


-- ---------------------------------------------------------------------
-- 4.3. TẠO GROUP - CƠ SỞ
-- HCM, HP, HN là các nhóm ngang hàng, không phải cấp bậc.
-- ---------------------------------------------------------------------
BEGIN
    SA_COMPONENTS.CREATE_GROUP(
        policy_name => 'THONGBAO_OLS',
        group_num   => 10,
        short_name  => 'HCM',
        long_name   => 'Ho Chi Minh'
    );

    SA_COMPONENTS.CREATE_GROUP(
        policy_name => 'THONGBAO_OLS',
        group_num   => 20,
        short_name  => 'HP',
        long_name   => 'Hai Phong'
    );

    SA_COMPONENTS.CREATE_GROUP(
        policy_name => 'THONGBAO_OLS',
        group_num   => 30,
        short_name  => 'HN',
        long_name   => 'Ha Noi'
    );

    DBMS_OUTPUT.PUT_LINE('Da tao GROUP: HCM, HP, HN.');
END;
/


-- =====================================================================
-- PHẦN 5. TẠO DATA LABEL CHO CÁC THÔNG BÁO T1..T7
-- =====================================================================

BEGIN
    -- t1: Gửi đến toàn bộ nhân viên
    SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 101,
        label_value => 'NV',
        data_label  => TRUE
    );

    -- t2: Gửi đến toàn bộ Ban Giám đốc
    SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 102,
        label_value => 'BGD',
        data_label  => TRUE
    );

    -- t3: Gửi đến các lãnh đạo khoa
    SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 103,
        label_value => 'LDK',
        data_label  => TRUE
    );

    -- t4: Gửi đến lãnh đạo Khoa tiêu hóa
    SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 104,
        label_value => 'LDK:TH',
        data_label  => TRUE
    );

    -- t5: Gửi đến nhân viên Khoa tiêu hóa ở Hồ Chí Minh
    SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 105,
        label_value => 'NV:TH:HCM',
        data_label  => TRUE
    );

    -- t6: Gửi đến nhân viên Khoa tiêu hóa ở Hà Nội
    SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 106,
        label_value => 'NV:TH:HN',
        data_label  => TRUE
    );

    -- t7: Gửi đến lãnh đạo Khoa tiêu hóa và Khoa thần kinh tại Hải Phòng
    SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 107,
        label_value => 'LDK:TH,TK:HP',
        data_label  => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('Da tao DATA LABEL T1..T7.');
END;
/


-- =====================================================================
-- PHẦN 6. ÁP POLICY VÀO BẢNG THONGBAO
-- Sau bước này Oracle sẽ tự thêm cột OLS_LABEL vào bảng THONGBAO.
-- =====================================================================

BEGIN
    SA_POLICY_ADMIN.APPLY_TABLE_POLICY(
        policy_name    => 'THONGBAO_OLS',
        schema_name    => 'ADMINHOS',
        table_name     => 'THONGBAO',
        table_options  => 'READ_CONTROL,WRITE_CONTROL,CHECK_CONTROL',
        label_function => NULL,
        predicate      => NULL
    );

    DBMS_OUTPUT.PUT_LINE('Da apply policy vao ADMINHOS.THONGBAO.');
END;
/


-- Kiểm tra cột OLS_LABEL đã được thêm chưa
SELECT COLUMN_NAME
FROM USER_TAB_COLUMNS
WHERE TABLE_NAME = 'THONGBAO'
  AND COLUMN_NAME = 'OLS_LABEL';


-- =====================================================================
-- PHẦN 7. GÁN FULL OLS CHO ADMINHOS ĐỂ NHẬP DỮ LIỆU
-- =====================================================================
BEGIN
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'ADMINHOS',
        max_read_label  => 'BGD:TH,TK,TM:HCM,HP,HN',
        max_write_label => 'BGD:TH,TK,TM:HCM,HP,HN',
        min_write_label => 'NV',
        def_label       => 'BGD:TH,TK,TM:HCM,HP,HN',
        row_label       => 'BGD:TH,TK,TM:HCM,HP,HN'
    );

    SA_USER_ADMIN.SET_USER_PRIVS(
        policy_name => 'THONGBAO_OLS',
        user_name   => 'ADMINHOS',
        privileges  => 'FULL'
    );

    DBMS_OUTPUT.PUT_LINE('Da gan FULL OLS cho ADMINHOS.');
END;
/

COMMIT;

-- Login lại để session ADMINHOS nhận quyền OLS mới
CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;
SET ROLE THONGBAO_OLS_DBA;

-- =====================================================================
-- PHẦN 8. THÊM DỮ LIỆU THÔNG BÁO T1..T7
-- =====================================================================

INSERT INTO ADMINHOS.THONGBAO (MATB, NOIDUNG, NGAYGIO, DIADIEM, OLS_LABEL)
VALUES (
    'T1',
    N'Thông báo họp khẩn gửi đến toàn bộ nhân viên bệnh viện.',
    SYSTIMESTAMP,
    N'Toàn hệ thống',
    CHAR_TO_LABEL('THONGBAO_OLS', 'NV')
);

INSERT INTO ADMINHOS.THONGBAO (MATB, NOIDUNG, NGAYGIO, DIADIEM, OLS_LABEL)
VALUES (
    'T2',
    N'Thông báo họp khẩn dành cho Ban Giám đốc.',
    SYSTIMESTAMP,
    N'Phòng họp Ban Giám đốc',
    CHAR_TO_LABEL('THONGBAO_OLS', 'BGD')
);

INSERT INTO ADMINHOS.THONGBAO (MATB, NOIDUNG, NGAYGIO, DIADIEM, OLS_LABEL)
VALUES (
    'T3',
    N'Thông báo họp khẩn dành cho các lãnh đạo khoa.',
    SYSTIMESTAMP,
    N'Phòng họp liên khoa',
    CHAR_TO_LABEL('THONGBAO_OLS', 'LDK')
);

INSERT INTO ADMINHOS.THONGBAO (MATB, NOIDUNG, NGAYGIO, DIADIEM, OLS_LABEL)
VALUES (
    'T4',
    N'Thông báo họp khẩn dành cho lãnh đạo Khoa tiêu hóa.',
    SYSTIMESTAMP,
    N'Khoa tiêu hóa',
    CHAR_TO_LABEL('THONGBAO_OLS', 'LDK:TH')
);

INSERT INTO ADMINHOS.THONGBAO (MATB, NOIDUNG, NGAYGIO, DIADIEM, OLS_LABEL)
VALUES (
    'T5',
    N'Thông báo họp khẩn dành cho nhân viên Khoa tiêu hóa tại Hồ Chí Minh.',
    SYSTIMESTAMP,
    N'Hồ Chí Minh',
    CHAR_TO_LABEL('THONGBAO_OLS', 'NV:TH:HCM')
);

INSERT INTO ADMINHOS.THONGBAO (MATB, NOIDUNG, NGAYGIO, DIADIEM, OLS_LABEL)
VALUES (
    'T6',
    N'Thông báo họp khẩn dành cho nhân viên Khoa tiêu hóa tại Hà Nội.',
    SYSTIMESTAMP,
    N'Hà Nội',
    CHAR_TO_LABEL('THONGBAO_OLS', 'NV:TH:HN')
);

INSERT INTO ADMINHOS.THONGBAO (MATB, NOIDUNG, NGAYGIO, DIADIEM, OLS_LABEL)
VALUES (
    'T7',
    N'Thông báo họp khẩn dành cho lãnh đạo Khoa tiêu hóa và Khoa thần kinh tại Hải Phòng.',
    SYSTIMESTAMP,
    N'Hải Phòng',
    CHAR_TO_LABEL('THONGBAO_OLS', 'LDK:TH,TK:HP')
);

COMMIT;


-- =====================================================================
-- PHẦN 9. TẠO USER DEMO U1..U8
-- Password dùng chung: Hos@123456
-- =====================================================================

CREATE OR REPLACE PROCEDURE SP_CREATE_OLS_USER (
    p_username IN VARCHAR2,
    p_password IN VARCHAR2 DEFAULT 'Hos@123456'
)
AS
    v_count NUMBER;
    v_user  VARCHAR2(30);
BEGIN
    v_user := UPPER(TRIM(p_username));

    SELECT COUNT(*)
    INTO v_count
    FROM DBA_USERS
    WHERE USERNAME = v_user;

    IF v_count = 0 THEN
        EXECUTE IMMEDIATE
            'CREATE USER ' || v_user || ' IDENTIFIED BY "' || p_password || '" ACCOUNT UNLOCK';
    ELSE
        EXECUTE IMMEDIATE
            'ALTER USER ' || v_user || ' IDENTIFIED BY "' || p_password || '" ACCOUNT UNLOCK';
    END IF;

    EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO ' || v_user;
END;
/

BEGIN
    SP_CREATE_OLS_USER('U1');
    SP_CREATE_OLS_USER('U2');
    SP_CREATE_OLS_USER('U3');
    SP_CREATE_OLS_USER('U4');
    SP_CREATE_OLS_USER('U5');
    SP_CREATE_OLS_USER('U6');
    SP_CREATE_OLS_USER('U7');
    SP_CREATE_OLS_USER('U8');

    DBMS_OUTPUT.PUT_LINE('Da tao user demo U1..U8.');
END;
/


-- =====================================================================
-- PHẦN 10. GÁN USER LABEL CHO U1..U8
-- =====================================================================

BEGIN
    -- U1: Giám đốc có thể đọc toàn bộ thông báo
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U1',
        max_read_label  => 'BGD:TH,TK,TM:HCM,HP,HN',
        max_write_label => 'BGD:TH,TK,TM:HCM,HP,HN',
        min_write_label => 'NV',
        def_label       => 'BGD:TH,TK,TM:HCM,HP,HN',
        row_label       => 'BGD:TH,TK,TM:HCM,HP,HN'
    );

    -- U2: Lãnh đạo Khoa tim mạch tại Hồ Chí Minh
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U2',
        max_read_label  => 'LDK:TM:HCM',
        max_write_label => 'LDK:TM:HCM',
        min_write_label => 'NV',
        def_label       => 'LDK:TM:HCM',
        row_label       => 'LDK:TM:HCM'
    );

    -- U3: Lãnh đạo Khoa thần kinh tại Hà Nội
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U3',
        max_read_label  => 'LDK:TK:HN',
        max_write_label => 'LDK:TK:HN',
        min_write_label => 'NV',
        def_label       => 'LDK:TK:HN',
        row_label       => 'LDK:TK:HN'
    );

    -- U4: Nhân viên Khoa thần kinh tại Hồ Chí Minh
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U4',
        max_read_label  => 'NV:TK:HCM',
        max_write_label => 'NV:TK:HCM',
        min_write_label => 'NV',
        def_label       => 'NV:TK:HCM',
        row_label       => 'NV:TK:HCM'
    );

    -- U5: Nhân viên Khoa tim mạch tại Hồ Chí Minh
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U5',
        max_read_label  => 'NV:TM:HCM',
        max_write_label => 'NV:TM:HCM',
        min_write_label => 'NV',
        def_label       => 'NV:TM:HCM',
        row_label       => 'NV:TM:HCM'
    );

    -- U6: Lãnh đạo phòng có thể đọc thông báo Khoa tim mạch tại Hồ Chí Minh
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U6',
        max_read_label  => 'LDK:TM:HCM',
        max_write_label => 'LDK:TM:HCM',
        min_write_label => 'NV',
        def_label       => 'LDK:TM:HCM',
        row_label       => 'LDK:TM:HCM'
    );

    -- U7: Lãnh đạo phòng đọc được toàn bộ thông báo phù hợp cấp lãnh đạo phòng
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U7',
        max_read_label  => 'LDK:TH,TK,TM:HCM,HP,HN',
        max_write_label => 'LDK:TH,TK,TM:HCM,HP,HN',
        min_write_label => 'NV',
        def_label       => 'LDK:TH,TK,TM:HCM,HP,HN',
        row_label       => 'LDK:TH,TK,TM:HCM,HP,HN'
    );

    -- U8: Nhân viên Khoa tiêu hóa tại Hà Nội
    SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U8',
        max_read_label  => 'NV:TH:HN',
        max_write_label => 'NV:TH:HN',
        min_write_label => 'NV',
        def_label       => 'NV:TH:HN',
        row_label       => 'NV:TH:HN'
    );

    DBMS_OUTPUT.PUT_LINE('Da gan OLS label cho U1..U8.');
END;
/


-- =====================================================================
-- PHẦN 11. TẠO VIEW HỖ TRỢ GIAO DIỆN
-- Không dùng public synonym.
-- User sẽ SELECT bằng ADMINHOS.VW_THONGBAO_APP.
-- =====================================================================

CREATE OR REPLACE VIEW ADMINHOS.VW_THONGBAO_APP AS
SELECT
    MATB,
    NOIDUNG,
    NGAYGIO,
    DIADIEM,
    LABEL_TO_CHAR(OLS_LABEL) AS NHAN_OLS
FROM ADMINHOS.THONGBAO;

GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO U1;
GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO U2;
GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO U3;
GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO U4;
GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO U5;
GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO U6;
GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO U7;
GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO U8;

-- =====================================================================
-- PHẦN 11B. GÁN OLS LABEL VÀ CẤP QUYỀN XEM THÔNG BÁO
-- CHO BÁC SĨ/Y SĨ, KỸ THUẬT VIÊN, ĐIỀU PHỐI VIÊN
-- =====================================================================

SET ROLE THONGBAO_OLS_DBA;

DECLARE
    v_comp  VARCHAR2(50);
    v_group VARCHAR2(50);
    v_label VARCHAR2(200);
BEGIN
    FOR r IN (
        SELECT 
            MANV,
            VAITRO,
            CHUYENKHOA,
            COSO
        FROM ADMINHOS.NHANVIEN
        WHERE VAITRO IN (
            N'Điều phối viên',
            N'Bác sĩ/Y sĩ',
            N'Kỹ thuật viên'
        )
        ORDER BY MANV
    ) LOOP

        -- Ánh xạ cơ sở
        IF r.COSO = N'Hồ Chí Minh' THEN
            v_group := 'HCM';
        ELSIF r.COSO = N'Hải Phòng' THEN
            v_group := 'HP';
        ELSIF r.COSO = N'Hà Nội' THEN
            v_group := 'HN';
        ELSE
            v_group := NULL;
        END IF;

        -- Ánh xạ chuyên khoa
        IF r.VAITRO = N'Điều phối viên' THEN
            -- Điều phối viên không có chuyên khoa,
            -- nhưng được xem thông báo cấp nhân viên của cả 3 khoa trong cùng cơ sở.
            v_comp := 'TH,TK,TM';

        ELSIF r.CHUYENKHOA = N'Khoa tiêu hóa' THEN
            v_comp := 'TH';

        ELSIF r.CHUYENKHOA = N'Khoa thần kinh' THEN
            v_comp := 'TK';

        ELSIF r.CHUYENKHOA = N'Khoa tim mạch' THEN
            v_comp := 'TM';

        ELSE
            v_comp := NULL;
        END IF;

        IF v_group IS NULL OR v_comp IS NULL THEN
            DBMS_OUTPUT.PUT_LINE(
                'Bo qua ' || r.MANV ||
                ' - thieu COSO hoac CHUYENKHOA hop le.'
            );
            CONTINUE;
        END IF;

        v_label := 'NV:' || v_comp || ':' || v_group;

        BEGIN
            SA_USER_ADMIN.SET_USER_LABELS(
                policy_name     => 'THONGBAO_OLS',
                user_name       => r.MANV,
                max_read_label  => v_label,
                max_write_label => v_label,
                min_write_label => 'NV',
                def_label       => v_label,
                row_label       => v_label
            );

            EXECUTE IMMEDIATE
                'GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO ' || r.MANV;

            DBMS_OUTPUT.PUT_LINE(
                'OK: ' || r.MANV || ' = ' || v_label
            );

        EXCEPTION
            WHEN OTHERS THEN
                DBMS_OUTPUT.PUT_LINE(
                    'LOI: ' || r.MANV || ' - ' || SQLERRM
                );
        END;

    END LOOP;

    DBMS_OUTPUT.PUT_LINE('Hoan tat gan OLS cho nhan vien.');
END;
/


-- =====================================================================
-- PHẦN 12. KIỂM TRA BẰNG ADMINHOS
-- ADMINHOS có FULL nên thấy toàn bộ.
-- =====================================================================
SHOW USER;
SELECT
    MATB,
    DIADIEM,
    LABEL_TO_CHAR(OLS_LABEL) AS NHAN_OLS
FROM ADMINHOS.THONGBAO
ORDER BY MATB;


-- =====================================================================
-- PHẦN 13. TEST USER DEMO
-- Lưu ý: không dùng synonym, dùng ADMINHOS.VW_THONGBAO_APP.
-- =====================================================================

-- U1: Giám đốc
-- Kỳ vọng: T1, T2, T3, T4, T5, T6, T7
CONNECT U1/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER;
SELECT MATB, DIADIEM, NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;


-- U2: Lãnh đạo Khoa tim mạch tại Hồ Chí Minh
-- Kỳ vọng: T1, T3
CONNECT U2/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER;
SELECT MATB, DIADIEM, NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;


-- U3: Lãnh đạo Khoa thần kinh tại Hà Nội
-- Kỳ vọng: T1, T3
CONNECT U3/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER;
SELECT MATB, DIADIEM, NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;


-- U4: Nhân viên Khoa thần kinh tại Hồ Chí Minh
-- Kỳ vọng: T1
CONNECT U4/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER;
SELECT MATB, DIADIEM, NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;


-- U5: Nhân viên Khoa tim mạch tại Hồ Chí Minh
-- Kỳ vọng: T1
CONNECT U5/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER;
SELECT MATB, DIADIEM, NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;


-- U6: Lãnh đạo phòng / Khoa tim mạch tại Hồ Chí Minh
-- Kỳ vọng: T1, T3
CONNECT U6/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER;
SELECT MATB, DIADIEM, NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;


-- U7: Lãnh đạo phòng toàn hệ thống
-- Kỳ vọng: T1, T3, T4, T5, T6, T7
CONNECT U7/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER;
SELECT MATB, DIADIEM, NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;


-- U8: Nhân viên Khoa tiêu hóa tại Hà Nội
-- Kỳ vọng: T1, T6
CONNECT U8/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER;
SELECT MATB, DIADIEM, NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;


-- ==========================================================
-- PHÂN HỆ 2 - YÊU CẦU 3
-- VẬN DỤNG CƠ CHẾ KIỂM TOÁN
-- ==========================================================

CONNECT SYS AS SYSDBA;

ALTER SESSION SET CONTAINER = PDBHOSX;

SET SERVEROUTPUT ON;


-- Kiểm tra chế độ audit hiện tại
SHOW PARAMETER audit_trail;

CONNECT SYS AS SYSDBA;

ALTER SESSION SET CONTAINER = PDBHOSX;

SET SERVEROUTPUT ON;

-- ==========================================================
-- KHỞI TẠO CLEANUP CHO STANDARD AUDIT
-- SYS.AUD$ / DBA_AUDIT_TRAIL
-- ==========================================================

BEGIN
    DBMS_AUDIT_MGMT.INIT_CLEANUP(
        audit_trail_type         => DBMS_AUDIT_MGMT.AUDIT_TRAIL_AUD_STD,
        default_cleanup_interval => 12
    );

    DBMS_OUTPUT.PUT_LINE('Da khoi tao cleanup cho Standard Audit.');
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE = -46263 THEN
            DBMS_OUTPUT.PUT_LINE('Standard Audit cleanup da duoc khoi tao truoc do, bo qua.');
        ELSE
            RAISE;
        END IF;
END;
/

-- ==========================================================
-- KHỞI TẠO CLEANUP CHO FINE-GRAINED AUDIT
-- SYS.FGA_LOG$ / DBA_FGA_AUDIT_TRAIL
-- ==========================================================

BEGIN
    DBMS_AUDIT_MGMT.INIT_CLEANUP(
        audit_trail_type         => DBMS_AUDIT_MGMT.AUDIT_TRAIL_FGA_STD,
        default_cleanup_interval => 12
    );

    DBMS_OUTPUT.PUT_LINE('Da khoi tao cleanup cho Fine-Grained Audit.');
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE = -46263 THEN
            DBMS_OUTPUT.PUT_LINE('Fine-Grained Audit cleanup da duoc khoi tao truoc do, bo qua.');
        ELSE
            RAISE;
        END IF;
END;
/

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- ==========================================================
-- XÓA FUNCTION / PROCEDURE CŨ NẾU ĐÃ TỒN TẠI
-- ==========================================================

BEGIN
    EXECUTE IMMEDIATE 'DROP FUNCTION FN_DEM_DONTHUOC';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -4043 THEN
            RAISE;
        END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP PROCEDURE SP_CAPNHAT_KETLUAN_HSBA';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -4043 THEN
            RAISE;
        END IF;
END;
/

-- ==========================================================
-- TẠO FUNCTION DEMO
-- Mục đích: Đếm số đơn thuốc của một hồ sơ bệnh án
-- ==========================================================

CREATE OR REPLACE FUNCTION FN_DEM_DONTHUOC (
    p_mahsba IN VARCHAR2
)
RETURN NUMBER
AS
    v_count NUMBER;
BEGIN
    SELECT COUNT(*)
    INTO v_count
    FROM DONTHUOC
    WHERE MAHSBA = p_mahsba;

    RETURN v_count;
END;
/

-- ==========================================================
-- TẠO PROCEDURE DEMO
-- Mục đích: Cập nhật kết luận hồ sơ bệnh án
-- ==========================================================

CREATE OR REPLACE PROCEDURE SP_CAPNHAT_KETLUAN_HSBA (
    p_mahsba  IN VARCHAR2,
    p_ketluan IN NVARCHAR2
)
AS
BEGIN
    UPDATE HSBA
    SET KETLUAN = p_ketluan
    WHERE MAHSBA = p_mahsba;

    COMMIT;
END;
/

-- Cấp quyền execute cho bác sĩ demo
GRANT EXECUTE ON FN_DEM_DONTHUOC TO BS0001;
GRANT EXECUTE ON FN_DEM_DONTHUOC TO BS0002;

GRANT EXECUTE ON SP_CAPNHAT_KETLUAN_HSBA TO BS0001;
GRANT EXECUTE ON SP_CAPNHAT_KETLUAN_HSBA TO BS0002;

CONNECT adminHos/123@localhost:1521/PDBHOSX

-- để test
GRANT SELECT ON HSBA TO BS0001;
GRANT UPDATE (CHANDOAN, DIEUTRI, KETLUAN) ON HSBA TO BS0001;

SET SERVEROUTPUT ON;

-- ==========================================================
-- XÓA CẤU HÌNH AUDIT CŨ NẾU CÓ
-- ==========================================================

NOAUDIT SELECT, INSERT, UPDATE, DELETE ON ADMINHOS.HSBA;
NOAUDIT SELECT, UPDATE ON ADMINHOS.VW_NHANVIEN_SELF;
NOAUDIT SELECT, UPDATE ON ADMINHOS.VW_BENHNHAN_SELF;
NOAUDIT EXECUTE ON ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA;
NOAUDIT EXECUTE ON ADMINHOS.FN_DEM_DONTHUOC;
NOAUDIT INSERT, UPDATE, DELETE ON ADMINHOS.HSBA_DV;

CONNECT SYS AS SYSDBA;

ALTER SESSION SET CONTAINER = PDBHOSX;

SET SERVEROUTPUT ON;

-- ==========================================================
-- XÓA LOG STANDARD AUDIT
-- Tương ứng với DBA_AUDIT_TRAIL / SYS.AUD$
-- ==========================================================

BEGIN
    DBMS_AUDIT_MGMT.CLEAN_AUDIT_TRAIL(
        audit_trail_type        => DBMS_AUDIT_MGMT.AUDIT_TRAIL_AUD_STD,
        use_last_arch_timestamp => FALSE
    );

    DBMS_OUTPUT.PUT_LINE('Da xoa Standard Audit Trail.');
END;
/


-- ==========================================================
-- XÓA LOG FINE-GRAINED AUDIT
-- Tương ứng với DBA_FGA_AUDIT_TRAIL / SYS.FGA_LOG$
-- ==========================================================

BEGIN
    DBMS_AUDIT_MGMT.CLEAN_AUDIT_TRAIL(
        audit_trail_type        => DBMS_AUDIT_MGMT.AUDIT_TRAIL_FGA_STD,
        use_last_arch_timestamp => FALSE
    );

    DBMS_OUTPUT.PUT_LINE('Da xoa Fine-Grained Audit Trail.');
END;
/

-- ==========================================================
-- NGỮ CẢNH 1:
-- Audit hành vi SELECT/UPDATE thành công trên bảng HSBA
-- Mục đích: theo dõi bác sĩ xem/cập nhật hồ sơ bệnh án
-- ==========================================================

AUDIT SELECT, UPDATE ON ADMINHOS.HSBA
BY ACCESS
WHENEVER SUCCESSFUL;

-- ==========================================================
-- NGỮ CẢNH 2:
-- Audit hành vi SELECT/UPDATE thất bại trên bảng HSBA
-- Mục đích: phát hiện user không có quyền nhưng cố truy cập HSBA
-- ==========================================================

AUDIT SELECT, UPDATE ON ADMINHOS.HSBA
BY ACCESS
WHENEVER NOT SUCCESSFUL;

-- ==========================================================
-- NGỮ CẢNH 3:
-- Audit hành vi SELECT/UPDATE thành công trên view nhân viên tự xem/cập nhật
-- Mục đích: theo dõi nhân viên cập nhật thông tin cá nhân
-- ==========================================================

AUDIT SELECT, UPDATE ON ADMINHOS.VW_NHANVIEN_SELF
BY ACCESS
WHENEVER SUCCESSFUL;

-- ==========================================================
-- NGỮ CẢNH 4:
-- Audit hành vi SELECT/UPDATE thành công trên view bệnh nhân tự xem/cập nhật
-- Mục đích: theo dõi bệnh nhân cập nhật thông tin cá nhân
-- ==========================================================

AUDIT SELECT, UPDATE ON ADMINHOS.VW_BENHNHAN_SELF
BY ACCESS
WHENEVER SUCCESSFUL;

-- ==========================================================
-- NGỮ CẢNH 5:
-- Audit hành vi EXECUTE trên stored procedure và function
-- Mục đích: theo dõi user gọi chương trình xử lý dữ liệu
-- ==========================================================

AUDIT EXECUTE ON ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA
BY ACCESS
WHENEVER SUCCESSFUL;

AUDIT EXECUTE ON ADMINHOS.FN_DEM_DONTHUOC
BY ACCESS
WHENEVER SUCCESSFUL;

-- Audit thất bại khi user không có quyền execute
AUDIT EXECUTE ON ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA
BY ACCESS
WHENEVER NOT SUCCESSFUL;

AUDIT EXECUTE ON ADMINHOS.FN_DEM_DONTHUOC
BY ACCESS
WHENEVER NOT SUCCESSFUL;

-- ==========================================================
-- TEST 5 NGỮ CẢNH STANDARD AUDIT
-- ==========================================================

SET SERVEROUTPUT ON;
SET LINESIZE 200;
SET PAGESIZE 100;


-- ==========================================================
-- NGỮ CẢNH 1:
-- Audit SELECT / UPDATE thành công trên TABLE ADMINHOS.HSBA
-- User test: BS0001
-- Kỳ vọng:
--      SELECT thành công -> ghi audit SELECT, RETURNCODE = 0
--      UPDATE thành công -> ghi audit UPDATE, RETURNCODE = 0
-- ==========================================================

CONNECT BS0001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT BAC SI SELECT THANH CONG TREN ADMINHOS.HSBA
SELECT MAHSBA, MABN, MABS, CHANDOAN, DIEUTRI, KETLUAN
FROM ADMINHOS.HSBA
WHERE MAHSBA = 'HSBA00001';

PROMPT BAC SI UPDATE THANH CONG TREN ADMINHOS.HSBA
UPDATE ADMINHOS.HSBA
SET KETLUAN = N'Test standard audit update thanh cong boi BS0001'
WHERE MAHSBA = 'HSBA00001';

COMMIT;


-- ==========================================================
-- NGỮ CẢNH 2:
-- Audit SELECT / UPDATE thất bại trên TABLE ADMINHOS.HSBA
-- User test: BN000001
-- Kỳ vọng:
--      SELECT thất bại hoặc không đủ quyền -> ghi audit, RETURNCODE <> 0
--      UPDATE thất bại hoặc không đủ quyền -> ghi audit, RETURNCODE <> 0
-- Lưu ý:
--      Nếu BN000001 chưa được cấp quyền trực tiếp trên ADMINHOS.HSBA
--      thì sẽ lỗi ORA-00942 hoặc ORA-01031, đây là đúng mục tiêu test.
-- ==========================================================

CONNECT BN000001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT BENH NHAN SELECT THAT BAI TREN ADMINHOS.HSBA
SELECT MAHSBA, MABN, MABS, CHANDOAN, DIEUTRI, KETLUAN
FROM ADMINHOS.HSBA
WHERE MAHSBA = 'HSBA00001';

PROMPT BENH NHAN UPDATE THAT BAI TREN ADMINHOS.HSBA
UPDATE ADMINHOS.HSBA
SET KETLUAN = N'Test standard audit update that bai boi BN000001'
WHERE MAHSBA = 'HSBA00001';

COMMIT;


-- ==========================================================
-- NGỮ CẢNH 3:
-- Audit SELECT / UPDATE thành công trên VIEW ADMINHOS.VW_NHANVIEN_SELF
-- User test: BS0001
-- Kỳ vọng:
--      SELECT chính thông tin nhân viên của mình -> thành công
--      UPDATE QUEQUAN/SODT của chính mình -> thành công
--      Ghi audit trên view VW_NHANVIEN_SELF, RETURNCODE = 0
-- ==========================================================

CONNECT BS0001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT BAC SI SELECT THONG TIN CA NHAN TREN ADMINHOS.VW_NHANVIEN_SELF
SELECT MANV, HOTEN, QUEQUAN, SODT
FROM ADMINHOS.VW_NHANVIEN_SELF;

PROMPT BAC SI UPDATE THONG TIN CA NHAN TREN ADMINHOS.VW_NHANVIEN_SELF
UPDATE ADMINHOS.VW_NHANVIEN_SELF
SET SODT = '0999000001'
WHERE MANV = 'BS0001';

COMMIT;


-- ==========================================================
-- NGỮ CẢNH 4:
-- Audit SELECT / UPDATE thành công trên VIEW ADMINHOS.VW_BENHNHAN_SELF
-- User test: BN000001
-- Kỳ vọng:
--      SELECT chính thông tin bệnh nhân của mình -> thành công
--      UPDATE địa chỉ/tiền sử của chính mình -> thành công
--      Ghi audit trên view VW_BENHNHAN_SELF, RETURNCODE = 0
-- ==========================================================

CONNECT BN000001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT BENH NHAN SELECT THONG TIN CA NHAN TREN ADMINHOS.VW_BENHNHAN_SELF
SELECT MABN, TENBN, SONHA, TENDUONG, QUANHUYEN, TINHTP
FROM ADMINHOS.VW_BENHNHAN_SELF;

PROMPT BENH NHAN UPDATE THONG TIN CA NHAN TREN ADMINHOS.VW_BENHNHAN_SELF
UPDATE ADMINHOS.VW_BENHNHAN_SELF
SET SONHA = N'123',
    TENDUONG = N'Duong Test Audit',
    QUANHUYEN = N'Quan Test',
    TINHTP = N'Ho Chi Minh'
WHERE MABN = 'BN000001';

COMMIT;


-- ==========================================================
-- NGỮ CẢNH 5:
-- Audit EXECUTE thành công/thất bại trên PROCEDURE và FUNCTION
--
-- Đối tượng:
--      ADMINHOS.FN_DEM_DONTHUOC
--      ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA
--
-- User test thành công: BS0001
-- User test thất bại: BN000001
-- Kỳ vọng:
--      BS0001 EXECUTE thành công -> RETURNCODE = 0
--      BN000001 EXECUTE thất bại nếu không được grant execute -> RETURNCODE <> 0
-- ==========================================================

CONNECT BS0001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT BAC SI EXECUTE FUNCTION ADMINHOS.FN_DEM_DONTHUOC THANH CONG
SELECT ADMINHOS.FN_DEM_DONTHUOC('HSBA00001') AS SO_DONTHUOC
FROM DUAL;

PROMPT BAC SI EXECUTE PROCEDURE ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA THANH CONG
BEGIN
    ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA(
        p_mahsba  => 'HSBA00001',
        p_ketluan => N'Test execute procedure thanh cong boi BS0001'
    );
END;
/

CONNECT BN000001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT BENH NHAN EXECUTE FUNCTION ADMINHOS.FN_DEM_DONTHUOC THAT BAI
SELECT ADMINHOS.FN_DEM_DONTHUOC('HSBA00001') AS SO_DONTHUOC
FROM DUAL;

PROMPT BENH NHAN EXECUTE PROCEDURE ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA THAT BAI
BEGIN
    ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA(
        p_mahsba  => 'HSBA00001',
        p_ketluan => N'Test execute procedure that bai boi BN000001'
    );
END;
/


-- ==========================================================
-- ĐỌC LOG STANDARD AUDIT CHO 5 NGỮ CẢNH
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET LINESIZE 220;
SET PAGESIZE 100;

COLUMN USERNAME FORMAT A15;
COLUMN OWNER FORMAT A15;
COLUMN OBJ_NAME FORMAT A30;
COLUMN ACTION_NAME FORMAT A20;
COLUMN RETURNCODE FORMAT 999999;
COLUMN AUDIT_TIME FORMAT A20;

PROMPT DOC LOG STANDARD AUDIT CHO 5 NGU CANH
SELECT
    USERNAME,
    OWNER,
    OBJ_NAME,
    ACTION_NAME,
    RETURNCODE,
    TO_CHAR(TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS') AS AUDIT_TIME
FROM DBA_AUDIT_TRAIL
WHERE OWNER = 'ADMINHOS'
  AND OBJ_NAME IN (
      'HSBA',
      'VW_NHANVIEN_SELF',
      'VW_BENHNHAN_SELF',
      'SP_CAPNHAT_KETLUAN_HSBA',
      'FN_DEM_DONTHUOC'
  )
  AND USERNAME IN ('BS0001', 'BN000001')
ORDER BY TIMESTAMP DESC;


CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;


-- ==========================================================
-- 3.3. FINE-GRAINED AUDIT CHO CÁC TÌNH HUỐNG NGHIỆP VỤ
-- ==========================================================
-- Mục tiêu:
-- a. Audit hành vi bác sĩ/y sĩ cập nhật đơn thuốc sau khi đơn thuốc đã được tạo.
-- b. Audit hành vi bác sĩ cập nhật hợp pháp CHANDOAN, DIEUTRI, KETLUAN
--    trên hồ sơ bệnh án do chính bác sĩ đó điều trị.
-- c. Audit hành vi cập nhật bất hợp pháp CHANDOAN, DIEUTRI, KETLUAN
--    trên hồ sơ bệnh án không do user đó điều trị.
-- d. Audit hành vi thêm, xóa, sửa bất hợp pháp trên HSBA_DV.
--
-- Ghi chú:
-- - FGA ghi nhận tốt nhất khi câu lệnh đã chạy tới được bảng.
-- - Nếu user không có quyền từ đầu và bị ORA-00942/ORA-01031,
--   Standard Audit WHENEVER NOT SUCCESSFUL sẽ ghi nhận.
-- - Với các hành vi "bất hợp pháp về nghiệp vụ", ta cấp quyền thao tác
--   để câu lệnh chạy tới bảng, sau đó FGA ghi nhận theo điều kiện nghiệp vụ.
-- ==========================================================


CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;


-- ==========================================================
-- 3.3.1. XÓA FGA POLICY CŨ NẾU ĐÃ TỒN TẠI
-- ==========================================================

BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'DONTHUOC',
        policy_name   => 'FGA_DONTHUOC_UPDATE'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA',
        policy_name   => 'FGA_HSBA_UPDATE_HOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA',
        policy_name   => 'FGA_HSBA_UPDATE_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- Policy cũ nếu trước đó đã tạo chung cho HSBA_DV
BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'FGA_HSBA_DV_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- Policy mới cho INSERT bất hợp pháp trên HSBA_DV
BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'FGA_HSBA_DV_INSERT_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- Policy mới cho UPDATE/DELETE bất hợp pháp trên HSBA_DV
BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


-- ==========================================================
-- 3.3.2. POLICY CHO YÊU CẦU 3.a
-- ==========================================================
-- Yêu cầu:
-- Audit hành vi cập nhật trên các thuộc tính:
-- MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
-- của quan hệ DONTHUOC bởi bác sĩ/y sĩ sau khi đơn thuốc đã được tạo.
--
-- Giải thích:
-- - Vì hành vi là UPDATE nên bản ghi đơn thuốc đã tồn tại trước đó.
-- - Điều kiện audit: user hiện tại có username dạng BS%.
-- - Chỉ audit khi update các cột liên quan đến đơn thuốc.
-- ==========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'DONTHUOC',
        policy_name        => 'FGA_DONTHUOC_UPDATE',
        audit_condition    => 'SYS_CONTEXT(''USERENV'', ''SESSION_USER'') LIKE ''BS%''',
        audit_column       => 'MAHSBA,NGAYDT,TENTHUOC,LIEUDUNG',
        statement_types    => 'UPDATE',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
        audit_column_opts  => DBMS_FGA.ANY_COLUMNS
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_DONTHUOC_UPDATE');
END;
/


-- ==========================================================
-- 3.3.3. POLICY CHO YÊU CẦU 3.b
-- ==========================================================
-- Yêu cầu:
-- Audit hành vi của user thuộc vai trò Y sĩ/Bác sĩ cập nhật thành công
-- trên các trường CHANDOAN, DIEUTRI, KETLUAN của hồ sơ bệnh án
-- mà chính bác sĩ đó điều trị.
--
-- Giải thích:
-- - Trong bảng HSBA, cột MABS lưu bác sĩ phụ trách hồ sơ.
-- - Hợp pháp khi SESSION_USER = MABS.
-- - Ví dụ: BS0001 cập nhật HSBA00001 nếu HSBA00001 có MABS = BS0001.
-- ==========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA',
        policy_name        => 'FGA_HSBA_UPDATE_HOPPHAP',
        audit_condition    => 'SYS_CONTEXT(''USERENV'', ''SESSION_USER'') = MABS',
        audit_column       => 'CHANDOAN,DIEUTRI,KETLUAN',
        statement_types    => 'UPDATE',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
        audit_column_opts  => DBMS_FGA.ANY_COLUMNS
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_HSBA_UPDATE_HOPPHAP');
END;
/


-- ==========================================================
-- 3.3.4. POLICY CHO YÊU CẦU 3.c
-- ==========================================================
-- Yêu cầu:
-- Audit hành vi cập nhật bất hợp pháp trên các trường:
-- CHANDOAN, DIEUTRI, KETLUAN.
--
-- Giải thích:
-- - Bất hợp pháp về nghiệp vụ khi user hiện tại khác bác sĩ phụ trách MABS.
-- - Ví dụ: BS0001 cập nhật hồ sơ có MABS = BS0002.
-- - Trường hợp user không có quyền và bị chặn từ đầu thì Standard Audit
--   WHENEVER NOT SUCCESSFUL sẽ ghi nhận.
-- ==========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA',
        policy_name        => 'FGA_HSBA_UPDATE_BATHOPPHAP',
        audit_condition    => 'SYS_CONTEXT(''USERENV'', ''SESSION_USER'') <> NVL(MABS, ''#'')',
        audit_column       => 'CHANDOAN,DIEUTRI,KETLUAN',
        statement_types    => 'UPDATE',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
        audit_column_opts  => DBMS_FGA.ANY_COLUMNS
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_HSBA_UPDATE_BATHOPPHAP');
END;
/


-- ==========================================================
-- 3.3.5. POLICY CHO YÊU CẦU 3.d - INSERT BẤT HỢP PHÁP HSBA_DV
-- ==========================================================
-- Yêu cầu:
-- Audit hành vi THÊM bất hợp pháp trên HSBA_DV.
--
-- Giải thích:
-- - HSBA_DV là bảng dịch vụ hỗ trợ chẩn đoán.
-- - Trong bài toán, kỹ thuật viên mới là người phù hợp thao tác dịch vụ.
-- - Xem INSERT bất hợp pháp khi user hiện tại không phải KTV%.
-- - Để FGA ghi nhận được, trong phần test ta cố ý cấp INSERT cho BS0001,
--   rồi để FGA ghi nhận đây là hành vi bất hợp pháp về nghiệp vụ.
-- ==========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA_DV',
        policy_name        => 'FGA_HSBA_DV_INSERT_BATHOPPHAP',
        audit_condition    => 'SYS_CONTEXT(''USERENV'', ''SESSION_USER'') NOT LIKE ''KTV%''',
        audit_column       => NULL,
        statement_types    => 'INSERT',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_HSBA_DV_INSERT_BATHOPPHAP');
END;
/


-- ==========================================================
-- 3.3.6. POLICY CHO YÊU CẦU 3.d - UPDATE/DELETE BẤT HỢP PHÁP HSBA_DV
-- ==========================================================
-- Yêu cầu:
-- Audit hành vi SỬA/XÓA bất hợp pháp trên HSBA_DV.
--
-- Giải thích:
-- - Mỗi dòng HSBA_DV có MAKTV là kỹ thuật viên được phân công.
-- - Hợp pháp khi SESSION_USER = MAKTV.
-- - Bất hợp pháp khi SESSION_USER khác MAKTV.
-- - Ví dụ: KTV001 cập nhật/xóa dòng có MAKTV = KTV002.
-- ==========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA_DV',
        policy_name        => 'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP',
        audit_condition    => 'SYS_CONTEXT(''USERENV'', ''SESSION_USER'') <> NVL(MAKTV, ''#'')',
        audit_column       => NULL,
        statement_types    => 'UPDATE,DELETE',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_HSBA_DV_UPD_DEL_BATHOPPHAP');
END;
/


-- ==========================================================
-- 3.3.7. CẤP QUYỀN PHỤC VỤ KIỂM THỬ FGA
-- ==========================================================
-- Ghi chú:
-- - Các quyền này nhằm tạo dữ liệu kiểm thử cho audit.
-- - Một số quyền được cấp cố ý để câu lệnh chạy tới bảng,
--   từ đó FGA có thể ghi nhận hành vi bất hợp pháp về nghiệp vụ.
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

-- Cho BS0001, BS0002 xem và cập nhật HSBA để test hợp pháp/bất hợp pháp.
GRANT SELECT ON ADMINHOS.HSBA TO BS0001;
GRANT SELECT ON ADMINHOS.HSBA TO BS0002;

GRANT UPDATE (CHANDOAN, DIEUTRI, KETLUAN) ON ADMINHOS.HSBA TO BS0001;
GRANT UPDATE (CHANDOAN, DIEUTRI, KETLUAN) ON ADMINHOS.HSBA TO BS0002;

-- Cho BS0001 cập nhật DONTHUOC để test yêu cầu 3.a.
GRANT SELECT ON ADMINHOS.DONTHUOC TO BS0001;
GRANT UPDATE (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) ON ADMINHOS.DONTHUOC TO BS0001;

-- Cho BS0001 INSERT HSBA_DV để test hành vi thêm bất hợp pháp về nghiệp vụ.
-- Lưu ý: Đây là quyền cấp để tạo tình huống audit, không phải quyền nghiệp vụ đúng.
GRANT INSERT ON ADMINHOS.HSBA_DV TO BS0001;

-- Cho KTV001 thao tác HSBA_DV để test sửa/xóa bất hợp pháp trên dòng không thuộc mình.
GRANT SELECT ON ADMINHOS.HSBA_DV TO KTV001;
GRANT UPDATE (KETQUA) ON ADMINHOS.HSBA_DV TO KTV001;
GRANT DELETE ON ADMINHOS.HSBA_DV TO KTV001;

-- Cố tình không cấp quyền trên HSBA, HSBA_DV cho DP0001/BN000001
-- để Standard Audit có thể ghi nhận các hành vi thất bại nếu cần.

-- ==========================================================
-- 3.3.8. KIỂM TRA DỮ LIỆU TRƯỚC KHI TEST
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

PROMPT [3.3.8.1] KIEM TRA DU LIEU MAU TREN BANG HSBA - HSBA00001 VA HSBA00002
SELECT MAHSBA, MABN, MABS, CHANDOAN, DIEUTRI, KETLUAN
FROM HSBA
WHERE MAHSBA IN ('HSBA00001', 'HSBA00002')
ORDER BY MAHSBA;

PROMPT [3.3.8.2] KIEM TRA DON THUOC DA TON TAI CUA HSBA00001
SELECT MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
FROM DONTHUOC
WHERE MAHSBA = 'HSBA00001';

PROMPT [3.3.8.3] KIEM TRA DONG DICH VU HSBA_DV CUA HSBA00002
SELECT MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA
FROM HSBA_DV
WHERE MAHSBA = 'HSBA00002';


-- ==========================================================
-- 3.3.9. TEST YÊU CẦU 3.b
-- Bác sĩ cập nhật hợp pháp HSBA do chính mình điều trị.
-- ==========================================================
-- Dữ liệu mẫu:
-- HSBA00001 có MABS = BS0001.
-- Do đó BS0001 cập nhật HSBA00001 là hợp pháp.
-- Kỳ vọng:
-- - Câu lệnh UPDATE thành công.
-- - DBA_FGA_AUDIT_TRAIL có policy FGA_HSBA_UPDATE_HOPPHAP.
-- ==========================================================

CONNECT BS0001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT [3.3.9] TEST 3.b - BS0001 UPDATE HOP PHAP HSBA00001 DO CHINH MINH PHU TRACH
UPDATE ADMINHOS.HSBA
SET CHANDOAN = N'Chẩn đoán hợp pháp bởi BS0001',
    DIEUTRI  = N'Điều trị hợp pháp bởi BS0001',
    KETLUAN  = N'Kết luận hợp pháp bởi BS0001'
WHERE MAHSBA = 'HSBA00001';

COMMIT;


-- ==========================================================
-- 3.3.10. TEST YÊU CẦU 3.a
-- Bác sĩ cập nhật đơn thuốc sau khi đơn thuốc đã được tạo.
-- ==========================================================
-- Dữ liệu mẫu:
-- DONTHUOC của HSBA00001 đã tồn tại.
-- Kỳ vọng:
-- - BS0001 update LIEUDUNG thành công.
-- - DBA_FGA_AUDIT_TRAIL có policy FGA_DONTHUOC_UPDATE.
-- ==========================================================

CONNECT BS0001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT [3.3.10] TEST 3.a - BS0001 UPDATE LIEUDUNG TREN DONTHUOC DA TON TAI CUA HSBA00001
UPDATE ADMINHOS.DONTHUOC
SET LIEUDUNG = N'Uống 3 lần/ngày sau ăn'
WHERE MAHSBA = 'HSBA00001';

COMMIT;


-- ==========================================================
-- 3.3.11. TEST YÊU CẦU 3.c
-- Bác sĩ cập nhật bất hợp pháp HSBA không do mình điều trị.
-- ==========================================================
-- Dữ liệu mẫu:
-- HSBA00002 thường có MABS = BS0002.
-- BS0001 cập nhật HSBA00002 là bất hợp pháp về nghiệp vụ.
-- Kỳ vọng:
-- - Câu lệnh UPDATE có thể thành công do đã cấp quyền để test.
-- - DBA_FGA_AUDIT_TRAIL có policy FGA_HSBA_UPDATE_BATHOPPHAP.
-- ==========================================================

-- Cấp tạm thời quyền bypass VPD cho BS0001 để test audit 3.c. Vì bác sĩ bị gán VPD
-- EXEMPT ACCESS POLICY không ảnh hưởng FGA — audit vẫn ghi nhận.
-- Quyền này sẽ bị thu hồi ngay sau khi test.
CONNECT SYS@localhost:1521/PDBHOSX AS SYSDBA
GRANT EXEMPT ACCESS POLICY TO BS0001;


CONNECT BS0001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT [3.3.11] TEST 3.c - BS0001 UPDATE BAT HOP PHAP HSBA00002 KHONG DO MINH PHU TRACH
UPDATE ADMINHOS.HSBA
SET KETLUAN = N'Cập nhật bất hợp pháp bởi BS0001'
WHERE MAHSBA = 'HSBA00002';

COMMIT;

-- Thu hồi quyền bypass VPD — khôi phục trạng thái bảo mật ban đầu.
CONNECT SYS@localhost:1521/PDBHOSX AS SYSDBA
REVOKE EXEMPT ACCESS POLICY FROM BS0001;

-- ==========================================================
-- 3.3.12. TEST YÊU CẦU 3.d - THÊM BẤT HỢP PHÁP HSBA_DV
-- ==========================================================
-- Tình huống:
-- BS0001 không phải kỹ thuật viên nhưng cố INSERT vào HSBA_DV.
-- Vì đã cấp INSERT để tạo tình huống, câu lệnh có thể chạy tới bảng.
-- FGA sẽ ghi nhận vì SESSION_USER không LIKE 'KTV%'.
--
-- Kỳ vọng:
-- - DBA_FGA_AUDIT_TRAIL có policy FGA_HSBA_DV_INSERT_BATHOPPHAP.
-- ==========================================================

CONNECT BS0001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT [3.3.12] TEST 3.d - BS0001 INSERT BAT HOP PHAP VAO HSBA_DV DO KHONG PHAI KTV
INSERT INTO ADMINHOS.HSBA_DV (MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA)
VALUES (
    'HSBA00001',
    N'Dịch vụ trái phép',
    SYSDATE,
    'KTV001',
    N'Trái phép'
);


-- ==========================================================
-- 3.3.13. TEST YÊU CẦU 3.d - SỬA BẤT HỢP PHÁP HSBA_DV
-- ==========================================================
-- Tình huống:
-- KTV001 cập nhật dòng HSBA_DV không được phân công cho mình.
-- Ví dụ HSBA00002 thường có MAKTV = KTV002.
-- Điều kiện bất hợp pháp: SESSION_USER <> MAKTV.
--
-- Kỳ vọng:
-- - UPDATE có thể thành công do đã cấp quyền để test.
-- - DBA_FGA_AUDIT_TRAIL có policy FGA_HSBA_DV_UPD_DEL_BATHOPPHAP.
-- ==========================================================

CONNECT KTV001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT [3.3.13] TEST 3.d - KTV001 UPDATE BAT HOP PHAP HSBA_DV CUA KTV KHAC
UPDATE ADMINHOS.HSBA_DV
SET KETQUA = N'Cập nhật sai phân công bởi KTV001'
WHERE MAHSBA = 'HSBA00002';


-- ==========================================================
-- 3.3.14. TEST YÊU CẦU 3.d - XÓA BẤT HỢP PHÁP HSBA_DV
-- ==========================================================
-- Tình huống:
-- KTV001 xóa dòng HSBA_DV không được phân công cho mình.
--
-- Kỳ vọng:
-- - DELETE có thể thành công do đã cấp quyền để test.
-- - DBA_FGA_AUDIT_TRAIL có policy FGA_HSBA_DV_UPD_DEL_BATHOPPHAP.
-- ==========================================================

CONNECT KTV001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT [3.3.14] TEST 3.d - KTV001 DELETE BAT HOP PHAP HSBA_DV CUA KTV KHAC
DELETE FROM ADMINHOS.HSBA_DV
WHERE MAHSBA = 'HSBA00002';


-- ==========================================================
-- 3.3.15. TEST THÊM: HÀNH VI THẤT BẠI DO KHÔNG CÓ QUYỀN
-- ==========================================================
-- Tình huống:
-- DP0001 cố cập nhật HSBA nhưng không được cấp quyền trực tiếp.
-- Hành vi này thường được ghi nhận bởi Standard Audit WHENEVER NOT SUCCESSFUL.
--
-- Ghi chú:
-- - Đây không phải log FGA chính, nhưng giúp chứng minh audit thất bại.
-- ==========================================================

CONNECT DP0001/"Hos@123456"@localhost:1521/PDBHOSX

PROMPT [3.3.15] TEST THEM - DP0001 UPDATE HSBA THAT BAI DO KHONG CO QUYEN
UPDATE ADMINHOS.HSBA
SET KETLUAN = N'Điều phối viên cố cập nhật trái phép'
WHERE MAHSBA = 'HSBA00001';

COMMIT;


-- ==========================================================
-- 3.4. ĐỌC XUẤT DỮ LIỆU KIỂM TOÁN
-- ==========================================================


-- ==========================================================
-- 3.4.1. ĐỌC STANDARD AUDIT TRAIL
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET LINESIZE 220;
SET PAGESIZE 100;

COLUMN USERNAME FORMAT A15;
COLUMN OWNER FORMAT A15;
COLUMN OBJ_NAME FORMAT A30;
COLUMN ACTION_NAME FORMAT A20;
COLUMN RETURNCODE FORMAT 999999;
COLUMN AUDIT_TIME FORMAT A20;

PROMPT [3.4.1] DOC STANDARD AUDIT TRAIL - CAC HANH VI THANH CONG VA THAT BAI TREN OBJECT
SELECT
    USERNAME,
    OWNER,
    OBJ_NAME,
    ACTION_NAME,
    RETURNCODE,
    TO_CHAR(TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS') AS AUDIT_TIME
FROM DBA_AUDIT_TRAIL
WHERE OWNER = 'ADMINHOS'
  AND OBJ_NAME IN (
      'HSBA',
      'DONTHUOC',
      'HSBA_DV',
      'VW_NHANVIEN_SELF',
      'VW_BENHNHAN_SELF',
      'SP_CAPNHAT_KETLUAN_HSBA',
      'FN_DEM_DONTHUOC'
  )
ORDER BY TIMESTAMP DESC;


-- ==========================================================
-- 3.4.2. ĐỌC FINE-GRAINED AUDIT TRAIL
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET LINESIZE 280;
SET PAGESIZE 100;

COLUMN DB_USER FORMAT A15;
COLUMN OBJECT_SCHEMA FORMAT A15;
COLUMN OBJECT_NAME FORMAT A20;
COLUMN POLICY_NAME FORMAT A35;
COLUMN STATEMENT_TYPE FORMAT A15;
COLUMN AUDIT_TIME FORMAT A20;
COLUMN SQL_TEXT FORMAT A100;

PROMPT [3.4.2] DOC FINE-GRAINED AUDIT TRAIL - TONG HOP LOG FGA CHO YEU CAU 3.a 3.b 3.c 3.d
SELECT
    DB_USER,
    OBJECT_SCHEMA,
    OBJECT_NAME,
    POLICY_NAME,
    STATEMENT_TYPE,
    TO_CHAR(EXTENDED_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS') AS AUDIT_TIME,
    SQL_TEXT
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'ADMINHOS'
  AND POLICY_NAME IN (
      'FGA_DONTHUOC_UPDATE',
      'FGA_HSBA_UPDATE_HOPPHAP',
      'FGA_HSBA_UPDATE_BATHOPPHAP',
      'FGA_HSBA_DV_INSERT_BATHOPPHAP',
      'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP'
  )
ORDER BY EXTENDED_TIMESTAMP DESC;


-- ==========================================================
-- 3.4.3. ĐỌC LOG RIÊNG CHO YÊU CẦU 3.a
-- ==========================================================

PROMPT [3.4.3] DOC LOG FGA RIENG - 3.a BAC SI UPDATE DONTHUOC DA TON TAI
SELECT
    DB_USER,
    OBJECT_NAME,
    POLICY_NAME,
    STATEMENT_TYPE,
    TO_CHAR(EXTENDED_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS') AS AUDIT_TIME,
    SQL_TEXT
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'ADMINHOS'
  AND POLICY_NAME = 'FGA_DONTHUOC_UPDATE'
ORDER BY EXTENDED_TIMESTAMP DESC;


-- ==========================================================
-- 3.4.4. ĐỌC LOG RIÊNG CHO YÊU CẦU 3.b
-- ==========================================================

PROMPT [3.4.4] DOC LOG FGA RIENG - 3.b BAC SI UPDATE HOP PHAP HSBA DO CHINH MINH PHU TRACH
SELECT
    DB_USER,
    OBJECT_NAME,
    POLICY_NAME,
    STATEMENT_TYPE,
    TO_CHAR(EXTENDED_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS') AS AUDIT_TIME,
    SQL_TEXT
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'ADMINHOS'
  AND POLICY_NAME = 'FGA_HSBA_UPDATE_HOPPHAP'
ORDER BY EXTENDED_TIMESTAMP DESC;


-- ==========================================================
-- 3.4.5. ĐỌC LOG RIÊNG CHO YÊU CẦU 3.c
-- ==========================================================

PROMPT [3.4.5] DOC LOG FGA RIENG - 3.c BAC SI UPDATE BAT HOP PHAP HSBA KHONG DO MINH PHU TRACH
SELECT
    DB_USER,
    OBJECT_NAME,
    POLICY_NAME,
    STATEMENT_TYPE,
    TO_CHAR(EXTENDED_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS') AS AUDIT_TIME,
    SQL_TEXT
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'ADMINHOS'
  AND POLICY_NAME = 'FGA_HSBA_UPDATE_BATHOPPHAP'
ORDER BY EXTENDED_TIMESTAMP DESC;


-- ==========================================================
-- 3.4.6. ĐỌC LOG RIÊNG CHO YÊU CẦU 3.d
-- ==========================================================

PROMPT [3.4.6] DOC LOG FGA RIENG - 3.d HSBA_DV INSERT UPDATE DELETE BAT HOP PHAP
SELECT
    DB_USER,
    OBJECT_NAME,
    POLICY_NAME,
    STATEMENT_TYPE,
    TO_CHAR(EXTENDED_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS') AS AUDIT_TIME,
    SQL_TEXT
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'ADMINHOS'
  AND POLICY_NAME IN (
      'FGA_HSBA_DV_INSERT_BATHOPPHAP',
      'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP'
  )
ORDER BY EXTENDED_TIMESTAMP DESC;




-- ==========================================================
-- PHÂN HỆ 2 - YÊU CẦU 4
-- SAO LƯU VÀ PHỤC HỒI DỮ LIỆU
-- ==========================================================


-- ==========================================================
-- YÊU CẦU 4.2: HIỆN THỰC CÁC PHƯƠNG PHÁP SAO LƯU VÀ PHỤC HỒI
-- Gồm 3 phương pháp chính được thực hiện trên Oracle:
--   A. RMAN (Recovery Manager)         – sao lưu vật lý toàn bộ hoặc gia tăng
--   B. Data Pump (expdp / impdp)       – sao lưu logic ở mức schema / bảng
--   C. Oracle Flashback                – phục hồi nhanh dữ liệu bị thay đổi
--      (Flashback Query, Flashback Table, Flashback Drop, Flashback Database)
-- ==========================================================


-- ==========================================================
-- PHƯƠNG PHÁP A: RMAN (Recovery Manager)
-- Mô tả: Sao lưu vật lý datafile, control file, redo log
--        của toàn bộ PDB PDBHOSX; hỗ trợ full và incremental.
-- Ghi chú: Lệnh RMAN chạy từ command-line OS (không phải SQL*Plus).
--          Các lệnh SQL kiểm tra phía dưới chạy được trực tiếp.
-- ==========================================================


-- ==========================================================
-- A.1. KIỂM TRA ĐIỀU KIỆN TIÊN QUYẾT (chạy bằng SYSDBA)
-- Kỳ vọng: LOG_MODE = ARCHIVELOG, DB_RECOVERY_FILE_DEST đã cấu hình
-- ==========================================================

CONNECT SYS@localhost:1521/PDBHOSX AS SYSDBA;

PROMPT [A.1.1] KIEM TRA ARCHIVELOG MODE - Ky vong: LOG_MODE = ARCHIVELOG
SELECT
    NAME,
    DB_UNIQUE_NAME,
    LOG_MODE,
    FLASHBACK_ON
FROM V$DATABASE;


PROMPT [A.1.2] KIEM TRA THAM SO FAST RECOVERY AREA VA UNDO
SELECT NAME, VALUE
FROM V$PARAMETER
WHERE NAME IN (
    'db_recovery_file_dest',
    'db_recovery_file_dest_size',
    'undo_retention',
    'db_flashback_retention_target',
    'log_archive_dest_1'
)
ORDER BY NAME;


PROMPT [A.1.3] KIEM TRA DUNG LUONG FAST RECOVERY AREA
SELECT
    SPACE_LIMIT / 1024 / 1024 / 1024    AS LIMIT_GB,
    SPACE_USED  / 1024 / 1024 / 1024    AS USED_GB,
    SPACE_RECLAIMABLE / 1024 / 1024     AS RECLAIMABLE_MB,
    NUMBER_OF_FILES
FROM V$RECOVERY_FILE_DEST;


-- ==========================================================
-- A.2. KIỂM TRA TRẠNG THÁI ARCHIVELOG
-- Kỳ vọng: Danh sách các archived log đã được tạo
-- ==========================================================

PROMPT [A.2] KIEM TRA ARCHIVED LOG GAN NHAT
SELECT
    SEQUENCE#,
    FIRST_TIME,
    NEXT_TIME,
    ARCHIVED,
    STATUS,
    NAME
FROM V$ARCHIVED_LOG
WHERE DEST_ID = 1
ORDER BY SEQUENCE# DESC
FETCH FIRST 5 ROWS ONLY;


-- ==========================================================
-- A.3. KIỂM TRA BẢN SAO LƯU RMAN ĐÃ THỰC HIỆN
-- Kỳ vọng: Nếu đã chạy RMAN backup, hiện danh sách bản backup
-- ==========================================================

PROMPT [A.3] KIEM TRA BAN SAO LUU RMAN QUA V$BACKUP_SET
SELECT
    BS.SET_STAMP,
    BS.SET_COUNT,
    BS.BACKUP_TYPE,
    BS.COMPLETION_TIME,
    BS.STATUS,
    BP.DEVICE_TYPE,
    BP.HANDLE
FROM V$BACKUP_SET BS
JOIN V$BACKUP_PIECE BP ON BS.SET_STAMP = BP.SET_STAMP
                      AND BS.SET_COUNT = BP.SET_COUNT
ORDER BY BS.COMPLETION_TIME DESC
FETCH FIRST 10 ROWS ONLY;


-- ==========================================================
-- Hướng dẫn lệnh RMAN chạy từ OS (Command Prompt)
-- Thực hiện sau khi đã xác nhận ARCHIVELOG mode ở trên
-- ==========================================================

/*
====================================================================
RMAN - CÁC LỆNH CHẠY TỪ COMMAND-LINE OS
====================================================================

-- Kết nối RMAN vào PDB:
rman TARGET SYS/oracle@localhost:1521/PDBHOSX

-- Cấu hình một lần:
RMAN> CONFIGURE RETENTION POLICY TO REDUNDANCY 2;
RMAN> CONFIGURE BACKUP OPTIMIZATION ON;
RMAN> CONFIGURE CONTROLFILE AUTOBACKUP ON;
RMAN> CONFIGURE DEFAULT DEVICE TYPE TO DISK;
RMAN> CONFIGURE CHANNEL DEVICE TYPE DISK FORMAT 'D:\RMAN_BACKUP\%d_%T_%s.bkp';

-- Full Backup (kèm archived log):
RMAN> BACKUP DATABASE PLUS ARCHIVELOG DELETE INPUT;

-- Incremental Level 0 (baseline):
RMAN> BACKUP INCREMENTAL LEVEL 0 DATABASE PLUS ARCHIVELOG DELETE INPUT;

-- Incremental Level 1 Cumulative:
RMAN> BACKUP INCREMENTAL LEVEL 1 CUMULATIVE DATABASE PLUS ARCHIVELOG DELETE INPUT;

-- Validate bản backup (không thực sự phục hồi, chỉ kiểm tra):
RMAN> VALIDATE DATABASE;
RMAN> RESTORE DATABASE VALIDATE;

-- Liệt kê tóm tắt các bản backup:
RMAN> LIST BACKUP SUMMARY;

-- Phục hồi toàn bộ PDB sau sự cố:
RMAN> SHUTDOWN ABORT;
RMAN> STARTUP MOUNT;
RMAN> RESTORE DATABASE;
RMAN> RECOVER DATABASE;
RMAN> ALTER DATABASE OPEN RESETLOGS;

-- Phục hồi đến thời điểm cụ thể (PITR):
RMAN> RESTORE DATABASE UNTIL TIME "TO_DATE('2026-06-04 07:00:00','YYYY-MM-DD HH24:MI:SS')";
RMAN> RECOVER DATABASE UNTIL TIME "TO_DATE('2026-06-04 07:00:00','YYYY-MM-DD HH24:MI:SS')";
RMAN> ALTER DATABASE OPEN RESETLOGS;
====================================================================
*/


-- ==========================================================
-- PHƯƠNG PHÁP B: DATA PUMP (expdp / impdp)
-- Mô tả: Sao lưu logic toàn bộ schema ADMINHOS hoặc từng bảng.
-- ==========================================================


-- ==========================================================
-- B.1. CHUẨN BỊ: TẠO ORACLE DIRECTORY (chạy bằng SYSDBA)
-- Kỳ vọng: Directory DATAPUMP_DIR được tạo, ADMINHOS có READ/WRITE
-- Lưu ý: Thư mục D:\DATAPUMP_BACKUP phải được tạo thủ công trên OS trước
-- ==========================================================

CONNECT SYS AS SYSDBA;

ALTER SESSION SET CONTAINER = PDBHOSX;

BEGIN
    EXECUTE IMMEDIATE
        'CREATE OR REPLACE DIRECTORY DATAPUMP_DIR AS ''D:\DATAPUMP_BACKUP''';
    DBMS_OUTPUT.PUT_LINE('Da tao DIRECTORY DATAPUMP_DIR.');
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Loi tao DIRECTORY: ' || SQLERRM);
END;
/

GRANT READ, WRITE ON DIRECTORY DATAPUMP_DIR TO ADMINHOS;

PROMPT [B.1] XAC NHAN DIRECTORY DA TON TAI - Ky vong: DATAPUMP_DIR co duong dan D:\DATAPUMP_BACKUP
SELECT DIRECTORY_NAME, DIRECTORY_PATH
FROM DBA_DIRECTORIES
WHERE DIRECTORY_NAME = 'DATAPUMP_DIR';


-- ==========================================================
-- B.2. TEST DATA PUMP EXPORT BẰNG DBMS_DATAPUMP (chạy trong SQL)
-- Kỳ vọng: Job export chạy thành công, file .dmp xuất hiện trong D:\DATAPUMP_BACKUP
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

PROMPT [B.2] TEST EXPORT SCHEMA ADMINHOS QUA DBMS_DATAPUMP

DECLARE
    v_job_handle  NUMBER;
    v_status      VARCHAR2(30);
    v_job_state   VARCHAR2(30);
BEGIN
    -- Mở job export
    v_job_handle := DBMS_DATAPUMP.OPEN(
        operation  => 'EXPORT',
        job_mode   => 'SCHEMA',
        job_name   => 'TEST_EXPORT_YC4',
        version    => 'LATEST'
    );

    -- Thêm file dump
    DBMS_DATAPUMP.ADD_FILE(
        handle    => v_job_handle,
        filename  => 'adminhos_test_yc4.dmp',
        directory => 'DATAPUMP_DIR',
        filetype  => DBMS_DATAPUMP.KU$_FILE_TYPE_DUMP_FILE
    );

    -- Thêm file log
    DBMS_DATAPUMP.ADD_FILE(
        handle    => v_job_handle,
        filename  => 'adminhos_test_yc4.log',
        directory => 'DATAPUMP_DIR',
        filetype  => DBMS_DATAPUMP.KU$_FILE_TYPE_LOG_FILE
    );

    -- Lọc chỉ export schema ADMINHOS
    DBMS_DATAPUMP.METADATA_FILTER(
        handle => v_job_handle,
        name   => 'SCHEMA_EXPR',
        value  => '= ''ADMINHOS'''
    );

    -- Bắt đầu job và chờ hoàn tất
    DBMS_DATAPUMP.START_JOB(handle => v_job_handle);
    DBMS_DATAPUMP.WAIT_FOR_JOB(
        handle    => v_job_handle,
        job_state => v_job_state
    );

    DBMS_OUTPUT.PUT_LINE('Job export ket thuc voi trang thai: ' || v_job_state);

    DBMS_DATAPUMP.DETACH(handle => v_job_handle);
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Loi export: ' || SQLERRM);
        BEGIN
            DBMS_DATAPUMP.DETACH(handle => v_job_handle);
        EXCEPTION WHEN OTHERS THEN NULL;
        END;
END;
/


-- ==========================================================
-- B.3. KIỂM TRA KẾT QUẢ EXPORT
-- Kỳ vọng: Không còn job nào ở trạng thái đang chạy (STATE = COMPLETED hoặc rỗng)
-- ==========================================================

CONNECT SYS AS SYSDBA;
ALTER SESSION SET CONTAINER = PDBHOSX;

PROMPT [B.3] KIEM TRA TRANG THAI JOB DATA PUMP - Ky vong: Khong con job dang chay
SELECT JOB_NAME, OPERATION, JOB_MODE, STATE, DEGREE, ATTACHED_SESSIONS
FROM DBA_DATAPUMP_JOBS
ORDER BY JOB_NAME;


-- ==========================================================
-- B.4. TEST DATA PUMP IMPORT - PHỤC HỒI BẢNG DONTHUOC
-- Kịch bản: Giả lập mất dữ liệu DONTHUOC -> import lại từ file .dmp
-- Kỳ vọng: Bảng DONTHUOC được phục hồi đầy đủ dữ liệu ban đầu
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- Ghi lại số dòng trước khi xóa
PROMPT [B.4.1] DEM SO DONG DONTHUOC TRUOC KHI XOA - Ky vong: 100 dong
SELECT COUNT(*) AS SO_DONG_TRUOC_XOA FROM DONTHUOC;

-- Mô phỏng mất dữ liệu
DELETE FROM DONTHUOC;
COMMIT;

PROMPT [B.4.2] XAC NHAN DONTHUOC BI XOA - Ky vong: 0 dong
SELECT COUNT(*) AS SO_DONG_SAU_XOA FROM DONTHUOC;

-- Import lại từ file .dmp
DECLARE
    v_job_handle  NUMBER;
    v_job_state   VARCHAR2(30);
BEGIN
    v_job_handle := DBMS_DATAPUMP.OPEN(
        operation  => 'IMPORT',
        job_mode   => 'TABLE',
        job_name   => 'TEST_IMPORT_YC4'
    );

    DBMS_DATAPUMP.ADD_FILE(
        handle    => v_job_handle,
        filename  => 'adminhos_test_yc4.dmp',
        directory => 'DATAPUMP_DIR',
        filetype  => DBMS_DATAPUMP.KU$_FILE_TYPE_DUMP_FILE
    );

    DBMS_DATAPUMP.ADD_FILE(
        handle    => v_job_handle,
        filename  => 'adminhos_test_import_yc4.log',
        directory => 'DATAPUMP_DIR',
        filetype  => DBMS_DATAPUMP.KU$_FILE_TYPE_LOG_FILE
    );

    -- Chỉ import bảng DONTHUOC
    DBMS_DATAPUMP.METADATA_FILTER(
        handle => v_job_handle,
        name   => 'NAME_EXPR',
        value  => '= ''DONTHUOC'''
    );

    -- Nếu bảng đã tồn tại thì bỏ qua DDL, chỉ import data
    DBMS_DATAPUMP.SET_PARAMETER(
        handle => v_job_handle,
        name   => 'TABLE_EXISTS_ACTION',
        value  => 'APPEND'
    );

    DBMS_DATAPUMP.START_JOB(handle => v_job_handle);
    DBMS_DATAPUMP.WAIT_FOR_JOB(
        handle    => v_job_handle,
        job_state => v_job_state
    );

    DBMS_OUTPUT.PUT_LINE('Job import ket thuc voi trang thai: ' || v_job_state);
    DBMS_DATAPUMP.DETACH(handle => v_job_handle);
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Loi import: ' || SQLERRM);
        BEGIN
            DBMS_DATAPUMP.DETACH(handle => v_job_handle);
        EXCEPTION WHEN OTHERS THEN NULL;
        END;
END;
/

PROMPT [B.4.3] KIEM TRA SAU IMPORT - Ky vong: 100 dong duoc phuc hoi
SELECT COUNT(*) AS SO_DONG_SAU_IMPORT FROM DONTHUOC;

PROMPT [B.4.4] KIEM TRA DU LIEU MAU SAU IMPORT
SELECT MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
FROM DONTHUOC
WHERE ROWNUM <= 5
ORDER BY MAHSBA;


-- ==========================================================
-- B.5. SAO LƯU TỰ ĐỘNG (SCHEDULER JOB)
-- Mục đích: Lên lịch export Data Pump tự động mỗi ngày lúc 02:00
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- Xóa job cũ nếu đã tồn tại
BEGIN
    DBMS_SCHEDULER.DROP_JOB(job_name => 'JOB_DAILY_DATAPUMP_BACKUP');
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

CREATE OR REPLACE PROCEDURE SP_RUN_DATAPUMP_BACKUP AS
    v_job_handle NUMBER;
BEGIN
    v_job_handle := DBMS_DATAPUMP.OPEN(
        operation  => 'EXPORT',
        job_mode   => 'SCHEMA',
        job_name   => 'DAILY_BACKUP_' || TO_CHAR(SYSDATE, 'YYYYMMDD'),
        version    => 'LATEST'
    );

    DBMS_DATAPUMP.ADD_FILE(
        handle    => v_job_handle,
        filename  => 'adminhos_auto_' || TO_CHAR(SYSDATE, 'YYYYMMDD') || '.dmp',
        directory => 'DATAPUMP_DIR',
        filetype  => DBMS_DATAPUMP.KU$_FILE_TYPE_DUMP_FILE
    );

    DBMS_DATAPUMP.ADD_FILE(
        handle    => v_job_handle,
        filename  => 'adminhos_auto_' || TO_CHAR(SYSDATE, 'YYYYMMDD') || '.log',
        directory => 'DATAPUMP_DIR',
        filetype  => DBMS_DATAPUMP.KU$_FILE_TYPE_LOG_FILE
    );

    DBMS_DATAPUMP.METADATA_FILTER(
        handle => v_job_handle,
        name   => 'SCHEMA_EXPR',
        value  => '= ''ADMINHOS'''
    );

    DBMS_DATAPUMP.START_JOB(handle => v_job_handle);
    DBMS_DATAPUMP.DETACH(handle => v_job_handle);

    DBMS_OUTPUT.PUT_LINE('Da khoi dong export tu dong ngay ' || TO_CHAR(SYSDATE, 'YYYY-MM-DD'));
END;
/

BEGIN
    DBMS_SCHEDULER.CREATE_JOB(
        job_name        => 'JOB_DAILY_DATAPUMP_BACKUP',
        job_type        => 'STORED_PROCEDURE',
        job_action      => 'ADMINHOS.SP_RUN_DATAPUMP_BACKUP',
        start_date      => TRUNC(SYSDATE + 1) + INTERVAL '2' HOUR,
        repeat_interval => 'FREQ=DAILY; BYHOUR=2; BYMINUTE=0; BYSECOND=0',
        enabled         => TRUE,
        comments        => 'Tu dong export schema ADMINHOS moi ngay luc 02:00'
    );
    DBMS_OUTPUT.PUT_LINE('Da tao Scheduler Job: JOB_DAILY_DATAPUMP_BACKUP');
END;
/

PROMPT [B.5] KIEM TRA SCHEDULER JOB DA DUOC TAO - Ky vong: JOB_DAILY_DATAPUMP_BACKUP o trang thai SCHEDULED
SELECT JOB_NAME, STATE, ENABLED,
       TO_CHAR(NEXT_RUN_DATE, 'YYYY-MM-DD HH24:MI:SS') AS NEXT_RUN
FROM USER_SCHEDULER_JOBS
WHERE JOB_NAME = 'JOB_DAILY_DATAPUMP_BACKUP';


-- ==========================================================
-- PHƯƠNG PHÁP C: ORACLE FLASHBACK
-- ==========================================================


-- ==========================================================
-- C.0. CHUẨN BỊ: BẬT ROW MOVEMENT VÀ KIỂM TRA CẤU HÌNH
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

ALTER TABLE DONTHUOC  ENABLE ROW MOVEMENT;
ALTER TABLE HSBA      ENABLE ROW MOVEMENT;
ALTER TABLE HSBA_DV   ENABLE ROW MOVEMENT;
ALTER TABLE BENHNHAN  ENABLE ROW MOVEMENT;
ALTER TABLE NHANVIEN  ENABLE ROW MOVEMENT;

PROMPT [C.0] KIEM TRA ROW MOVEMENT DA BAT - Ky vong: tat ca 5 bang la ENABLED
SELECT TABLE_NAME, ROW_MOVEMENT
FROM USER_TABLES
WHERE TABLE_NAME IN ('DONTHUOC','HSBA','HSBA_DV','BENHNHAN','NHANVIEN')
ORDER BY TABLE_NAME;


-- ==========================================================
-- C.1. FLASHBACK QUERY
-- Kịch bản: Ghi lại SCN trước khi sửa, sửa dữ liệu, dùng AS OF SCN truy vấn lại
-- Kỳ vọng: AS OF SCN trả về dữ liệu gốc TRƯỚC khi UPDATE
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- Bước C.1.1: Ghi lại SCN và dữ liệu hiện tại trước khi gây lỗi
DECLARE
    v_scn_before NUMBER;
    v_lieudung   NVARCHAR2(100);
BEGIN
    SELECT CURRENT_SCN INTO v_scn_before FROM V$DATABASE;
    SELECT LIEUDUNG INTO v_lieudung
    FROM DONTHUOC
    WHERE MAHSBA = 'HSBA00001'
      AND ROWNUM = 1;

    DBMS_OUTPUT.PUT_LINE('SCN truoc khi sua: ' || v_scn_before);
    DBMS_OUTPUT.PUT_LINE('LIEUDUNG goc: ' || v_lieudung);

    -- Lưu SCN vào bảng tạm để dùng lại
    EXECUTE IMMEDIATE
        'CREATE OR REPLACE VIEW VW_SCN_CHECKPOINT AS SELECT ' ||
        v_scn_before || ' AS SCN_BEFORE FROM DUAL';
END;
/

PROMPT [C.1.1] DU LIEU DONTHUOC TRUOC KHI SUA - Ky vong: LIEUDUNG co gia tri cu the
SELECT MAHSBA, TENTHUOC, LIEUDUNG
FROM DONTHUOC
WHERE MAHSBA = 'HSBA00001';

-- Bước C.1.2: Gây lỗi - thay đổi LIEUDUNG sai
UPDATE DONTHUOC
SET LIEUDUNG = N'[SAI - test flashback query]'
WHERE MAHSBA = 'HSBA00001';

COMMIT;

PROMPT [C.1.2] DU LIEU SAU KHI SUA SAI - Ky vong: LIEUDUNG = [SAI - test flashback query]
SELECT MAHSBA, TENTHUOC, LIEUDUNG
FROM DONTHUOC
WHERE MAHSBA = 'HSBA00001';

-- Bước C.1.3: Dùng Flashback Query AS OF SCN để xem lại dữ liệu gốc
PROMPT [C.1.3] FLASHBACK QUERY AS OF SCN - Ky vong: LIEUDUNG hien thi lai gia tri CU truoc khi sua
SELECT MAHSBA, TENTHUOC, LIEUDUNG
FROM DONTHUOC
AS OF SCN v_scn_truoc (SELECT SCN_BEFORE FROM VW_SCN_CHECKPOINT)
WHERE MAHSBA = 'HSBA00001';

-- Bước C.1.4: So sánh trực tiếp hiện tại vs quá khứ
PROMPT [C.1.4] SO SANH DU LIEU HIEN TAI VA QUA KHU
SELECT
    curr.MAHSBA,
    curr.LIEUDUNG                               AS LIEUDUNG_HIEN_TAI,
    hist.LIEUDUNG                               AS LIEUDUNG_TRUOC_KHI_SUA
FROM DONTHUOC curr
JOIN (
    SELECT MAHSBA, LIEUDUNG
    FROM DONTHUOC
    AS OF SCN v_scn_truoc (SELECT SCN_BEFORE FROM VW_SCN_CHECKPOINT)
    WHERE MAHSBA = 'HSBA00001'
) hist ON curr.MAHSBA = hist.MAHSBA
WHERE curr.MAHSBA = 'HSBA00001';

-- Bước C.1.5: Phục hồi dữ liệu từ Flashback Query
PROMPT [C.1.5] PHUC HOI DU LIEU TU FLASHBACK QUERY
DECLARE
    v_lieudung_cu NVARCHAR2(100);
    v_scn_before  NUMBER;
BEGIN
    SELECT SCN_BEFORE INTO v_scn_before FROM VW_SCN_CHECKPOINT;

    SELECT LIEUDUNG INTO v_lieudung_cu
    FROM DONTHUOC
    AS OF SCN v_scn_before
    WHERE MAHSBA = 'HSBA00001'
      AND ROWNUM = 1;

    UPDATE DONTHUOC
    SET LIEUDUNG = v_lieudung_cu
    WHERE MAHSBA = 'HSBA00001';

    COMMIT;
    DBMS_OUTPUT.PUT_LINE('Da phuc hoi LIEUDUNG: ' || v_lieudung_cu);
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('Khong tim thay du lieu flashback. SCN co the da het han.');
END;
/

PROMPT [C.1.6] XAC NHAN SAU PHUC HOI - Ky vong: LIEUDUNG tra ve gia tri goc ban dau
SELECT MAHSBA, TENTHUOC, LIEUDUNG
FROM DONTHUOC
WHERE MAHSBA = 'HSBA00001';

-- Dọn view tạm
BEGIN
    EXECUTE IMMEDIATE 'DROP VIEW VW_SCN_CHECKPOINT';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/


-- ==========================================================
-- C.2. FLASHBACK TABLE
-- Kịch bản: UPDATE sai hàng loạt đơn thuốc -> FLASHBACK TABLE về trước
-- Kỳ vọng: Bảng DONTHUOC khôi phục hoàn toàn về trạng thái trước UPDATE
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- Bước C.2.1: Ghi lại timestamp cố định trước khi gây lỗi
DECLARE
    v_ts TIMESTAMP := CAST(SYSTIMESTAMP AS TIMESTAMP);
BEGIN
    DBMS_OUTPUT.PUT_LINE('Thoi diem chup: ' || TO_CHAR(v_ts, 'YYYY-MM-DD HH24:MI:SS.FF3'));

    EXECUTE IMMEDIATE
        'CREATE OR REPLACE VIEW VW_TS_CHECKPOINT AS SELECT TO_TIMESTAMP('''
        || TO_CHAR(v_ts, 'YYYY-MM-DD HH24:MI:SS.FF3')
        || ''', ''YYYY-MM-DD HH24:MI:SS.FF3'') AS TS_BEFORE FROM DUAL';
END;
/

PROMPT [C.2.1] DU LIEU DONTHUOC TRUOC KHI GAY LOI
SELECT COUNT(*) AS TONG_DONG FROM DONTHUOC;
SELECT MAHSBA, TENTHUOC, LIEUDUNG
FROM DONTHUOC
WHERE ROWNUM <= 3
ORDER BY MAHSBA;

-- Bước C.2.2: Gây lỗi nghiêm trọng
UPDATE DONTHUOC
SET LIEUDUNG = N'[XOA NHAM - can phuc hoi]';

COMMIT;

PROMPT [C.2.2] DU LIEU SAU KHI CAP NHAT SAI
SELECT MAHSBA, TENTHUOC, LIEUDUNG
FROM DONTHUOC
WHERE ROWNUM <= 3
ORDER BY MAHSBA;

-- Bước C.2.3: Flashback Table về timestamp đã lưu
PROMPT [C.2.3] THUC HIEN FLASHBACK TABLE DONTHUOC

ALTER TABLE DONTHUOC ENABLE ROW MOVEMENT;

DECLARE
    v_ts TIMESTAMP;
BEGIN
    SELECT TS_BEFORE
    INTO v_ts
    FROM VW_TS_CHECKPOINT;

    EXECUTE IMMEDIATE
        'FLASHBACK TABLE DONTHUOC TO TIMESTAMP TO_TIMESTAMP('''
        || TO_CHAR(v_ts, 'YYYY-MM-DD HH24:MI:SS.FF3')
        || ''', ''YYYY-MM-DD HH24:MI:SS.FF3'')';

    DBMS_OUTPUT.PUT_LINE('Da flashback DONTHUOC ve: ' || TO_CHAR(v_ts, 'YYYY-MM-DD HH24:MI:SS.FF3'));
END;
/

-- Bước C.2.4: Kiểm tra sau phục hồi
PROMPT [C.2.4] DU LIEU SAU FLASHBACK TABLE
SELECT MAHSBA, TENTHUOC, LIEUDUNG
FROM DONTHUOC
WHERE ROWNUM <= 3
ORDER BY MAHSBA;

SELECT COUNT(*) AS TONG_DONG_SAU_PHUC_HOI
FROM DONTHUOC;

BEGIN
    EXECUTE IMMEDIATE 'DROP VIEW VW_TS_CHECKPOINT';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/


-- ==========================================================
-- C.3. FLASHBACK DROP (Recycle Bin)
-- Kịch bản: DROP nhầm bảng DEMO_FLASHBACK_DROP -> phục hồi từ Recycle Bin
-- Kỳ vọng: Bảng và dữ liệu được phục hồi hoàn toàn
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- Bước C.3.1: Tạo bảng demo và nhập dữ liệu
BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE DEMO_FLASHBACK_DROP PURGE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

CREATE TABLE DEMO_FLASHBACK_DROP (
    ID      NUMBER PRIMARY KEY,
    NOIDUNG NVARCHAR2(200)
);

INSERT INTO DEMO_FLASHBACK_DROP VALUES (1, N'Hồ sơ bệnh nhân quan trọng 001');
INSERT INTO DEMO_FLASHBACK_DROP VALUES (2, N'Kết quả xét nghiệm lưu trữ 002');
INSERT INTO DEMO_FLASHBACK_DROP VALUES (3, N'Đơn thuốc lịch sử cần giữ lại 003');

COMMIT;

PROMPT [C.3.1] BANG TRUOC KHI DROP - Ky vong: 3 dong du lieu
SELECT * FROM DEMO_FLASHBACK_DROP;

-- Bước C.3.2: Giả lập DROP nhầm
DROP TABLE DEMO_FLASHBACK_DROP;

PROMPT [C.3.2] KIEM TRA RECYCLE BIN - Ky vong: DEMO_FLASHBACK_DROP xuat hien trong RECYCLEBIN
SELECT OBJECT_NAME, ORIGINAL_NAME, TYPE, DROPTIME
FROM RECYCLEBIN
WHERE ORIGINAL_NAME = 'DEMO_FLASHBACK_DROP'
ORDER BY DROPTIME DESC;

-- Bước C.3.3: Phục hồi từ Recycle Bin
FLASHBACK TABLE DEMO_FLASHBACK_DROP TO BEFORE DROP;

PROMPT [C.3.3] DU LIEU SAU FLASHBACK DROP - Ky vong: 3 dong duoc phuc hoi day du
SELECT * FROM DEMO_FLASHBACK_DROP;

PROMPT [C.3.4] XAC NHAN KHONG CON TRONG RECYCLEBIN SAU PHUC HOI
SELECT COUNT(*) AS CON_TRONG_RECYCLEBIN
FROM RECYCLEBIN
WHERE ORIGINAL_NAME = 'DEMO_FLASHBACK_DROP';

-- Dọn dẹp sau demo
DROP TABLE DEMO_FLASHBACK_DROP PURGE;


-- ==========================================================
-- C.4. FLASHBACK DATABASE - KIỂM TRA CẤU HÌNH
-- Kỳ vọng: FLASHBACK_ON = YES nếu đã bật; hiển thị Flashback log space
-- ==========================================================

CONNECT SYS AS SYSDBA;

ALTER SESSION SET CONTAINER = PDBHOSX;

PROMPT [C.4.1] KIEM TRA TRANG THAI FLASHBACK DATABASE
SELECT
    DB_UNIQUE_NAME,
    LOG_MODE,
    FLASHBACK_ON
FROM V$DATABASE;

PROMPT [C.4.2] KIEM TRA FLASHBACK LOG SPACE
SELECT
    OLDEST_FLASHBACK_SCN,
    TO_CHAR(OLDEST_FLASHBACK_TIME, 'YYYY-MM-DD HH24:MI:SS') AS OLDEST_FLASHBACK_TIME,
    RETENTION_TARGET,
    FLASHBACK_SIZE / 1024 / 1024 AS FLASHBACK_SIZE_MB,
    ESTIMATED_FLASHBACK_SIZE / 1024 / 1024 AS ESTIMATED_MB
FROM V$FLASHBACK_DATABASE_LOG;

PROMPT [C.4.3] KIEM TRA THONG SO FLASHBACK RETENTION
SELECT NAME, VALUE
FROM V$PARAMETER
WHERE NAME = 'db_flashback_retention_target';

/*
====================================================================
NẾU FLASHBACK_ON = NO, CẦU HÌNH FLASHBACK DATABASE NHƯ SAU:
(Chạy từ SQL*Plus với SYSDBA tại CDB$ROOT)

ALTER SYSTEM SET DB_FLASHBACK_RETENTION_TARGET = 2880;
ALTER DATABASE FLASHBACK ON;

Phục hồi Flashback Database qua RMAN:

rman TARGET SYS/oracle@localhost:1521/PDBHOSX

RMAN> ALTER PLUGGABLE DATABASE PDBHOSX CLOSE IMMEDIATE;
RMAN> FLASHBACK PLUGGABLE DATABASE PDBHOSX
      TO TIMESTAMP TO_DATE('2026-06-04 07:00:00','YYYY-MM-DD HH24:MI:SS');
RMAN> ALTER PLUGGABLE DATABASE PDBHOSX OPEN RESETLOGS;
====================================================================
*/


-- ==========================================================
-- PHỤC HỒI DỰA VÀO NHẬT KÝ KIỂM TOÁN TỪ YÊU CẦU 3
-- Mô tả: Sau khi YC3 chạy xong, các sự cố thật đã xảy ra và
--        được FGA ghi nhận trong DBA_FGA_AUDIT_TRAIL.
--        YC4 đọc trực tiếp timestamp từ log đó để xác định
--        thời điểm sai, sau đó dùng Flashback phục hồi dữ liệu.
-- Gồm 2 phần:
--   - Phục hồi 3c: KETLUAN của HSBA00002 bị BS0001 cập nhật sai
--   - Phục hồi 3d: HSBA_DV bị INSERT giả / UPDATE sai / DELETE xóa
-- ==========================================================

CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;
SET LINESIZE 220;
SET PAGESIZE 100;


-- ==========================================================
-- ĐỌC TỔNG HỢP FGA LOG TỪ YÊU CẦU 3
-- Kỳ vọng: Hiện đủ các hành vi bất hợp pháp đã được ghi nhận
-- ==========================================================

PROMPT [FGA.0] TONG HOP LOG FGA TU YC3 - Ky vong: Co du log cho ca 3c va 3d
SELECT
    DB_USER,
    OBJECT_NAME,
    POLICY_NAME,
    STATEMENT_TYPE,
    TO_CHAR(EXTENDED_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS.FF3') AS THOI_DIEM_SAI,
    SQL_TEXT
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'ADMINHOS'
  AND POLICY_NAME IN (
      'FGA_HSBA_UPDATE_BATHOPPHAP',
      'FGA_HSBA_DV_INSERT_BATHOPPHAP',
      'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP'
  )
ORDER BY EXTENDED_TIMESTAMP DESC;


-- ==========================================================
-- PHỤC HỒI 3c: KETLUAN CỦA HSBA00002 BỊ BS0001 CẬP NHẬT SAI
-- Sự cố: BS0001 dùng EXEMPT ACCESS POLICY bypass VPD để UPDATE
--         HSBA00002 (thuộc BS0002) — FGA ghi log policy
--         FGA_HSBA_UPDATE_BATHOPPHAP.
-- Phương pháp: Flashback Query AS OF SCN trước thời điểm sự cố
--              → UPDATE lại giá trị đúng.
-- ==========================================================

PROMPT [FGA.3C.1] DU LIEU HSBA00002 HIEN TAI - Ky vong: KETLUAN bi cap nhat sai boi BS0001
SELECT MAHSBA, MABS, CHANDOAN, DIEUTRI, KETLUAN
FROM HSBA
WHERE MAHSBA = 'HSBA00002';


-- Lấy EXTENDED_TIMESTAMP từ FGA log của sự cố 3c, chuyển sang SCN trước sự cố
PROMPT [FGA.3C.2] LAY SCN TRUOC SU CO 3c TU FGA LOG
DECLARE
    v_ts_suco   TIMESTAMP WITH TIME ZONE;
    v_scn_truoc NUMBER;
BEGIN
    SELECT EXTENDED_TIMESTAMP
    INTO v_ts_suco
    FROM (
        SELECT EXTENDED_TIMESTAMP
        FROM DBA_FGA_AUDIT_TRAIL
        WHERE OBJECT_SCHEMA = 'ADMINHOS'
          AND OBJECT_NAME   = 'HSBA'
          AND POLICY_NAME   = 'FGA_HSBA_UPDATE_BATHOPPHAP'
          AND DB_USER       = 'BS0001'
        ORDER BY EXTENDED_TIMESTAMP DESC
    )
    WHERE ROWNUM = 1;

    DBMS_OUTPUT.PUT_LINE('[3c] Thoi diem su co: '
        || TO_CHAR(v_ts_suco, 'YYYY-MM-DD HH24:MI:SS.FF3'));

    -- Lùi 1 giây để lấy thời điểm ngay TRƯỚC sự cố
    v_scn_truoc := TIMESTAMP_TO_SCN(v_ts_suco - INTERVAL '1' SECOND);
    DBMS_OUTPUT.PUT_LINE('[3c] SCN truoc su co: ' || v_scn_truoc);

    EXECUTE IMMEDIATE
        'CREATE OR REPLACE VIEW VW_SCN_3C AS SELECT '
        || v_scn_truoc || ' AS SCN_TRUOC FROM DUAL';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE(
            'CANH BAO: Khong tim thay FGA log 3c. Kiem tra lai YC3 da chay chua.'
        );
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Loi: ' || SQLERRM);
END;
/

-- Phục hồi KETLUAN đúng từ Flashback Query
PROMPT [FGA.3C.4] PHUC HOI HSBA00002 KETLUAN TU FLASHBACK QUERY
DECLARE
    v_ketluan_dung NVARCHAR2(200);
    v_scn_truoc    NUMBER;
BEGIN
    SELECT SCN_TRUOC INTO v_scn_truoc FROM VW_SCN_3C;

    SELECT KETLUAN INTO v_ketluan_dung
    FROM HSBA
    AS OF SCN v_scn_truoc
    WHERE MAHSBA = 'HSBA00002';

    UPDATE HSBA
    SET KETLUAN = v_ketluan_dung
    WHERE MAHSBA = 'HSBA00002';

    COMMIT;
    DBMS_OUTPUT.PUT_LINE('[3c] Da phuc hoi KETLUAN: ' || v_ketluan_dung);
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE(
            'CANH BAO: Khong lay duoc du lieu flashback. ' ||
            'Undo co the da bi ghi de neu chay cach nhau qua lau.'
        );
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Loi phuc hoi 3c: ' || SQLERRM);
        ROLLBACK;
END;
/

PROMPT [FGA.3C.5] XAC NHAN SAU PHUC HOI 3c - Ky vong: KETLUAN tra ve gia tri hop le truoc su co
SELECT MAHSBA, MABS, CHANDOAN, DIEUTRI, KETLUAN
FROM HSBA
WHERE MAHSBA = 'HSBA00002';

BEGIN
    EXECUTE IMMEDIATE 'DROP VIEW VW_SCN_3C';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/


-- ==========================================================
-- PHỤC HỒI 3d: HSBA_DV BỊ TẠO/SỬA/XÓA BẤT HỢP PHÁP
-- Sự cố (theo thứ tự xảy ra trong YC3):
--   3.3.12: BS0001 INSERT 1 dòng giả vào HSBA_DV của HSBA00001
--   3.3.13: KTV001 UPDATE sai KETQUA của HSBA_DV HSBA00002
--   3.3.14: KTV001 DELETE toàn bộ HSBA_DV của HSBA00002
--           (xóa cả dòng vừa bị UPDATE sai ở 3.3.13)
-- Phương pháp phục hồi:
--   3.3.12 → DELETE dòng giả dựa vào SQL_TEXT từ FGA log (không cần Flashback)
--   3.3.13 → không cần phục hồi riêng vì 3.3.14 đã xóa dòng đó
--   3.3.14 → Flashback Query AS OF SCN trước 3.3.13 → INSERT lại các dòng gốc
-- ==========================================================


-- -----------------------------------------------------------
-- PHỤC HỒI 3d.1: XÓA DÒNG HSBA_DV GIẢ DO BS0001 INSERT (3.3.12)
-- Lấy SCN trước thời điểm INSERT bất hợp pháp.
-- Xác định thời điểm BS0001 insert dòng giả từ FGA log, dùng Flashback Query
-- So sánh HSBA_DV hiện tại với HSBA_DV AS OF SCN trước sự cố.
-- Dòng nào hiện tại có nhưng trước sự cố chưa có thì xóa.
-- -----------------------------------------------------------

PROMPT [FGA.3D.1] PHUC HOI INSERT BAT HOP PHAP TREN HSBA_DV

DECLARE
    v_ts_insert  TIMESTAMP WITH TIME ZONE;
    v_scn_truoc  NUMBER;
    v_scn_sau    NUMBER;
    v_rows       NUMBER := 0;
BEGIN
    SELECT EXTENDED_TIMESTAMP
    INTO v_ts_insert
    FROM (
        SELECT EXTENDED_TIMESTAMP
        FROM DBA_FGA_AUDIT_TRAIL
        WHERE OBJECT_SCHEMA  = 'ADMINHOS'
          AND OBJECT_NAME    = 'HSBA_DV'
          AND POLICY_NAME    = 'FGA_HSBA_DV_INSERT_BATHOPPHAP'
          AND STATEMENT_TYPE = 'INSERT'
        ORDER BY EXTENDED_TIMESTAMP ASC
    )
    WHERE ROWNUM = 1;

    v_scn_truoc := TIMESTAMP_TO_SCN(v_ts_insert - INTERVAL '1' SECOND);
    v_scn_sau   := TIMESTAMP_TO_SCN(v_ts_insert + INTERVAL '1' SECOND);

    DBMS_OUTPUT.PUT_LINE('[3d.1] Thoi diem INSERT sai: '
        || TO_CHAR(v_ts_insert, 'YYYY-MM-DD HH24:MI:SS.FF3'));
    DBMS_OUTPUT.PUT_LINE('[3d.1] SCN truoc INSERT: ' || v_scn_truoc);
    DBMS_OUTPUT.PUT_LINE('[3d.1] SCN sau INSERT: ' || v_scn_sau);

    DELETE FROM ADMINHOS.HSBA_DV curr
    WHERE EXISTS (
        SELECT 1
        FROM ADMINHOS.HSBA_DV AS OF SCN v_scn_sau after_insert
        WHERE after_insert.MAHSBA = curr.MAHSBA
          AND after_insert.LOAIDV = curr.LOAIDV
          AND after_insert.NGAYDV = curr.NGAYDV
          AND NOT EXISTS (
              SELECT 1
              FROM ADMINHOS.HSBA_DV AS OF SCN v_scn_truoc before_insert
              WHERE before_insert.MAHSBA = after_insert.MAHSBA
                AND before_insert.LOAIDV = after_insert.LOAIDV
                AND before_insert.NGAYDV = after_insert.NGAYDV
          )
    );

    v_rows := SQL%ROWCOUNT;
    COMMIT;

    DBMS_OUTPUT.PUT_LINE('[3d.1] Da xoa ' || v_rows || ' dong insert bat hop phap.');

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('[3d.1] Khong tim thay FGA log INSERT bat hop phap.');
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('[3d.1] Loi phuc hoi INSERT: ' || SQLERRM);
        ROLLBACK;
END;
/


-- ==========================================================
-- 3d.2. PHỤC HỒI UPDATE BẤT HỢP PHÁP
-- ==========================================================
-- Dùng khi KTV001 UPDATE sai HSBA_DV nhưng dòng vẫn còn tồn tại.
-- Nếu dòng đã bị DELETE sau UPDATE thì bước này không phục hồi được,
-- khi đó phải dùng bước 3d.3 để INSERT lại dòng đã bị xóa.
-- ==========================================================

PROMPT [FGA.3D.2] PHUC HOI UPDATE BAT HOP PHAP TREN HSBA_DV NEU DONG CON TON TAI

DECLARE
    v_ts_update  TIMESTAMP WITH TIME ZONE;
    v_scn_truoc  NUMBER;
    v_rows       NUMBER := 0;
    v_sql        VARCHAR2(4000);

    TYPE t_dv_rec IS RECORD (
        MAHSBA  ADMINHOS.HSBA_DV.MAHSBA%TYPE,
        LOAIDV  ADMINHOS.HSBA_DV.LOAIDV%TYPE,
        NGAYDV  ADMINHOS.HSBA_DV.NGAYDV%TYPE,
        MAKTV   ADMINHOS.HSBA_DV.MAKTV%TYPE,
        KETQUA  ADMINHOS.HSBA_DV.KETQUA%TYPE
    );

    TYPE t_dv_tab IS TABLE OF t_dv_rec INDEX BY PLS_INTEGER;
    v_tab t_dv_tab;
BEGIN
    -- Lấy lần UPDATE bất hợp pháp mới nhất của KTV001
    SELECT EXTENDED_TIMESTAMP
    INTO v_ts_update
    FROM (
        SELECT EXTENDED_TIMESTAMP
        FROM DBA_FGA_AUDIT_TRAIL
        WHERE OBJECT_SCHEMA  = 'ADMINHOS'
          AND OBJECT_NAME    = 'HSBA_DV'
          AND POLICY_NAME    = 'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP'
          AND DB_USER        = 'KTV001'
          AND STATEMENT_TYPE = 'UPDATE'
        ORDER BY EXTENDED_TIMESTAMP DESC
    )
    WHERE ROWNUM = 1;

    v_scn_truoc := TIMESTAMP_TO_SCN(v_ts_update - INTERVAL '1' SECOND);

    DBMS_OUTPUT.PUT_LINE('[3d.2] Thoi diem UPDATE sai: '
        || TO_CHAR(v_ts_update, 'YYYY-MM-DD HH24:MI:SS.FF3'));

    DBMS_OUTPUT.PUT_LINE('[3d.2] SCN truoc UPDATE: ' || v_scn_truoc);

    -- Lấy dữ liệu đúng trước khi UPDATE sai
    v_sql :=
        'SELECT hist.MAHSBA, hist.LOAIDV, hist.NGAYDV, hist.MAKTV, hist.KETQUA ' ||
        'FROM ( ' ||
        '    SELECT MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA ' ||
        '    FROM ADMINHOS.HSBA_DV AS OF SCN ' || v_scn_truoc ||
        ') hist ' ||
        'JOIN ADMINHOS.HSBA_DV curr ' ||
        '  ON curr.MAHSBA = hist.MAHSBA ' ||
        ' AND curr.LOAIDV = hist.LOAIDV ' ||
        ' AND curr.NGAYDV = hist.NGAYDV ' ||
        'WHERE NVL(curr.MAKTV,  ''#NULL#'') <> NVL(hist.MAKTV,  ''#NULL#'') ' ||
        '   OR NVL(curr.KETQUA, ''#NULL#'') <> NVL(hist.KETQUA, ''#NULL#'')';

    EXECUTE IMMEDIATE v_sql BULK COLLECT INTO v_tab;

    FOR i IN 1 .. v_tab.COUNT LOOP
        UPDATE ADMINHOS.HSBA_DV curr
        SET curr.MAKTV  = v_tab(i).MAKTV,
            curr.KETQUA = v_tab(i).KETQUA
        WHERE curr.MAHSBA = v_tab(i).MAHSBA
          AND curr.LOAIDV = v_tab(i).LOAIDV
          AND curr.NGAYDV = v_tab(i).NGAYDV;

        v_rows := v_rows + SQL%ROWCOUNT;
    END LOOP;

    COMMIT;

    DBMS_OUTPUT.PUT_LINE('[3d.2] Da phuc hoi ' || v_rows || ' dong bi UPDATE sai.');

    IF v_rows = 0 THEN
        DBMS_OUTPUT.PUT_LINE('[3d.2] Khong co dong nao duoc phuc hoi. Co the dong da bi DELETE hoac da duoc phuc hoi truoc do.');
    END IF;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('[3d.2] Khong tim thay FGA log UPDATE bat hop phap cua KTV001.');

    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('[3d.2] Loi phuc hoi UPDATE: ' || SQLERRM);
        ROLLBACK;
END;
/

-- ==========================================================
-- 3d.3. PHỤC HỒI DELETE BẤT HỢP PHÁP
-- ==========================================================
-- Nguyên tắc:
-- - Lấy SCN trước DELETE và sau DELETE để xác định dòng nào đã biến mất.
-- - Nếu trước DELETE đã có UPDATE sai, dữ liệu dùng để INSERT lại sẽ lấy từ
--   SCN trước sự cố UPDATE/DELETE đầu tiên, để khôi phục giá trị gốc.
-- - Nếu không có UPDATE trước DELETE thì SCN gốc chính là SCN trước DELETE.
-- ==========================================================

PROMPT [FGA.3D.3] PHUC HOI DELETE BAT HOP PHAP TREN HSBA_DV
DECLARE
    v_ts_first_up_del TIMESTAMP WITH TIME ZONE;
    v_scn_goc         NUMBER;
    v_rows            NUMBER := 0;
BEGIN
    SELECT MIN(EXTENDED_TIMESTAMP)
    INTO v_ts_first_up_del
    FROM DBA_FGA_AUDIT_TRAIL
    WHERE OBJECT_SCHEMA  = 'ADMINHOS'
      AND OBJECT_NAME    = 'HSBA_DV'
      AND POLICY_NAME    = 'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP'
      AND DB_USER        = 'KTV001'
      AND STATEMENT_TYPE IN ('UPDATE', 'DELETE');

    IF v_ts_first_up_del IS NULL THEN
        RAISE_APPLICATION_ERROR(
            -20001,
            'Khong tim thay FGA log UPDATE/DELETE bat hop phap cua KTV001.'
        );
    END IF;

    v_scn_goc := TIMESTAMP_TO_SCN(v_ts_first_up_del - INTERVAL '1' SECOND);

    DBMS_OUTPUT.PUT_LINE('[3d.3] Thoi diem su co UPDATE/DELETE dau tien: '
        || TO_CHAR(v_ts_first_up_del, 'YYYY-MM-DD HH24:MI:SS.FF3'));

    DBMS_OUTPUT.PUT_LINE('[3d.3] SCN goc truoc su co: ' || v_scn_goc);

    FOR g IN (
        SELECT MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA
        FROM ADMINHOS.HSBA_DV AS OF SCN v_scn_goc goc
        WHERE NOT EXISTS (
            SELECT 1
            FROM ADMINHOS.HSBA_DV curr
            WHERE curr.MAHSBA = goc.MAHSBA
              AND curr.LOAIDV = goc.LOAIDV
              AND curr.NGAYDV = goc.NGAYDV
        )
    )
    LOOP
        INSERT INTO ADMINHOS.HSBA_DV (
            MAHSBA,
            LOAIDV,
            NGAYDV,
            MAKTV,
            KETQUA
        )
        VALUES (
            g.MAHSBA,
            g.LOAIDV,
            g.NGAYDV,
            g.MAKTV,
            g.KETQUA
        );

        v_rows := v_rows + 1;

        DBMS_OUTPUT.PUT_LINE(
            '[3d.3] Phuc hoi dong bi xoa: ' ||
            g.MAHSBA || ' | ' ||
            g.LOAIDV || ' | ' ||
            TO_CHAR(g.NGAYDV, 'YYYY-MM-DD') || ' | ' ||
            g.MAKTV || ' | ' ||
            g.KETQUA
        );
    END LOOP;

    COMMIT;

    DBMS_OUTPUT.PUT_LINE('[3d.3] Da phuc hoi ' || v_rows || ' dong bi DELETE sai.');

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('[3d.3] Loi phuc hoi DELETE: ' || SQLERRM);
        ROLLBACK;
END;
/


-- ==========================================================
-- YÊU CẦU 4.4: KẾT LUẬN
-- ==========================================================

/*
====================================================================
KẾT LUẬN VỀ CÁC PHƯƠNG PHÁP SAO LƯU VÀ PHỤC HỒI DỮ LIỆU ORACLE
====================================================================

Sau khi tìm hiểu, thử nghiệm và hiện thực 3 phương pháp chính
trên hệ quản trị CSDL Oracle tại đồ án này, nhóm rút ra kết luận:

--------------------------------------------------------------------
1. RMAN (Recovery Manager) là giải pháp sao lưu vật lý toàn diện nhất.
--------------------------------------------------------------------
Ưu điểm:
  - Sao lưu toàn bộ dữ liệu vật lý: datafile, control file, redo log.
  - Hỗ trợ đầy đủ Full Backup và Incremental (Level 0/1),
    giúp tiết kiệm thời gian và dung lượng cho bản sao lưu gia tăng.
  - Phục hồi Point-in-Time (PITR) chính xác đến từng giây,
    rất quan trọng khi cần quay lại thời điểm cụ thể trước sự cố.
  - Tích hợp sẵn trong Oracle, có thể tự động hóa hoàn toàn.
  - Catalog lưu metadata bản sao lưu, cho phép kiểm tra và
    validate tính hợp lệ (VALIDATE DATABASE).

Nhược điểm:
  - Yêu cầu cấu hình ARCHIVELOG mode, tốn thêm dung lượng.
  - Phục hồi cần dừng dịch vụ (MOUNT mode), gây gián đoạn hệ thống.
  - Dung lượng file backup vật lý lớn hơn nhiều so với backup logic.
  - Cần người quản trị có kiến thức chuyên sâu về RMAN.

Phù hợp nhất với: Môi trường production cần phục hồi sau sự cố
nghiêm trọng (mất dữ liệu, hỏng đĩa, server bị xóa).

--------------------------------------------------------------------
2. DATA PUMP (expdp/impdp) là giải pháp backup logic linh hoạt.
--------------------------------------------------------------------
Ưu điểm:
  - Sao lưu ở mức logic: schema, bảng, hoặc tập dữ liệu lọc được.
  - Dễ chuyển dữ liệu giữa các phiên bản Oracle hoặc các môi trường khác nhau.
  - File .dmp nhỏ hơn backup vật lý nếu dùng COMPRESSION.
  - Phục hồi chọn lọc: chỉ import bảng cụ thể bị mất, không cần
    khôi phục toàn bộ database.
  - Có thể lên lịch tự động qua DBMS_DATAPUMP + DBMS_SCHEDULER.

Nhược điểm:
  - Không phục hồi được cấu trúc vật lý (tablespace, control file).
  - Không phù hợp khi dữ liệu thay đổi nhanh: backup tại thời điểm T
    chỉ phản ánh snapshot tại T, không có PITR.
  - Thời gian import với schema lớn (100.000 bệnh nhân) có thể lâu.
  - Khóa object đích trong quá trình import nếu dùng TABLE_EXISTS_ACTION=REPLACE.

Phù hợp nhất với: Sao lưu định kỳ, di chuyển dữ liệu giữa môi trường,
phục hồi khi một số bảng bị xóa hoặc hỏng logic.

--------------------------------------------------------------------
3. ORACLE FLASHBACK là công cụ phục hồi nhanh, ít gián đoạn nhất.
--------------------------------------------------------------------
Ưu điểm:
  - Flashback Query: xem dữ liệu quá khứ ngay trong session hiện tại,
    không cần khôi phục bất kỳ thứ gì, không gián đoạn hệ thống.
  - Flashback Table: phục hồi toàn bộ bảng chỉ với một lệnh SQL,
    hệ thống vẫn online trong quá trình phục hồi.
  - Flashback Drop: phục hồi bảng bị DROP nhầm từ Recycle Bin tức thì.
  - Tích hợp hoàn hảo với audit log (YC3): dùng FGA trail để xác định
    chính xác thời điểm sai, sau đó dùng Flashback Query phục hồi đúng dòng.
  - Không cần file backup ngoài, dựa vào Undo Segment sẵn có.

Nhược điểm:
  - Bị giới hạn bởi UNDO_RETENTION: dữ liệu quá khứ chỉ lưu trong
    khoảng thời gian cấu hình (thường 15 phút - vài giờ).
  - Flashback Database cần bật Flashback Logging, tốn thêm dung lượng Fast Recovery Area.
  - Không phục hồi được khi dữ liệu Undo đã bị ghi đè.
  - Flashback Table không hoạt động nếu cấu trúc bảng đã thay đổi (thêm/xóa cột).

Phù hợp nhất với: Phục hồi nhanh sau lỗi người dùng (UPDATE/DELETE sai),
đặc biệt hiệu quả khi kết hợp với audit log để khoanh vùng sự cố.

--------------------------------------------------------------------
TỔNG KẾT VÀ KHUYẾN NGHỊ
--------------------------------------------------------------------
Không có phương pháp nào là tuyệt đối tốt nhất. Chiến lược tối ưu
cho hệ thống bệnh viện X là kết hợp cả 3 lớp bảo vệ:

  - RMAN Full Backup hàng tuần + Incremental hàng ngày:
    bảo vệ trước sự cố vật lý nghiêm trọng.

  - Data Pump Export tự động hàng ngày (2:00 AM):
    snapshot logic nhanh, dễ phục hồi bảng cụ thể.

  - Oracle Flashback luôn bật (Undo Retention >= 24 giờ):
    xử lý lập tức các lỗi nhỏ trong ngày mà không gián đoạn dịch vụ.

  - Kết hợp với FGA Audit Trail (YC3):
    khi có sự cố, đọc log kiểm toán để xác định CHÍNH XÁC
    thời điểm và đối tượng bị thay đổi sai, từ đó chọn phương
    pháp phục hồi phù hợp nhất và tối thiểu hóa mất mát dữ liệu.
====================================================================
*/

CONNECT ADMINHOS/123@localhost:1521/PDBHOSX 
SHOW USER

SELECT COUNT(*), 
    HS.*,
    BN.TENBN AS TEN_BENH_NHAN,
    BS.HOTEN AS TEN_BACSI,
    BS.CHUYENKHOA AS CHUYENKHOA_BACSI,
    BS.COSO AS COSO_BACSI
FROM ADMINHOS.HSBA HS
JOIN ADMINHOS.NHANVIEN BS
    ON HS.MABS = BS.MANV
   AND TRIM(BS.VAITRO) = N'Bác sĩ/Y sĩ'
JOIN ADMINHOS.BENHNHAN BN
    ON HS.MABN = BN.MABN
WHERE TRIM(BS.COSO) = N'Hồ Chí Minh'
ORDER BY HS.MAHSBA;

                SELECT 
                    NV.MANV,
                    NV.HOTEN,
                    NV.CHUYENKHOA,
                    NV.COSO
                FROM ADMINHOS.NHANVIEN NV
                WHERE NV.VAITRO = N'Kỹ thuật viên'
                ORDER BY NV.MANV ASC;

INSERT INTO ADMINHOS.HSBA_DV (MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA)
VALUES ('HSBA00001', N'TEST - Chụp CT', SYSDATE, NULL, NULL);

INSERT INTO ADMINHOS.HSBA_DV (MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA)
VALUES ('HSBA00002', N'TEST - Xét nghiệm nước tiểu', SYSDATE + 1/1440, NULL, NULL);

INSERT INTO ADMINHOS.HSBA_DV (MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA)
VALUES ('HSBA00003', N'TEST - Điện tim', SYSDATE + 2/1440, NULL, NULL);

INSERT INTO ADMINHOS.HSBA_DV (MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA)
VALUES ('HSBA00004', N'TEST - Siêu âm ổ bụng', SYSDATE + 3/1440, NULL, NULL);

INSERT INTO ADMINHOS.HSBA_DV (MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA)
VALUES ('HSBA00005', N'TEST - Xét nghiệm máu nâng cao', SYSDATE + 4/1440, NULL, NULL);

COMMIT;


CONN BS0001/"Hos@123456"@localhost:1521/PDBHOSX
SELECT * FROM ADMINHOS.VW_NHANVIEN_SELF;

CONN DP0001/"Hos@123456"@localhost:1521/PDBHOSX
SHOW USER
                SELECT 
                    (SELECT COUNT(*) FROM ADMINHOS.HSBA) AS SO_HSBA,
                    (
                        SELECT COUNT(*) 
                        FROM ADMINHOS.HSBA_DV DV
                        JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
                    ) AS SO_PHAN_CONG
                FROM DUAL;
                
                SELECT 
                    NV.MANV,
                    NV.HOTEN,
                    NV.CHUYENKHOA,
                    NV.COSO
                FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI NV
                WHERE NV.VAITRO = N'Kỹ thuật viên'
                ORDER BY NV.MANV ASC;


SELECT * FROM ADMINHOS.VW_NHANVIEN_SELF;

SELECT 
    MATB,
    NOIDUNG,
    DIADIEM,
    NHAN_OLS
FROM ADMINHOS.VW_THONGBAO_APP
ORDER BY MATB;
               
            
               
