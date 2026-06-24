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
-- ==========================================================

-- ==========================================================
-- YÊU CẦU 1 - CÂU 1 +  CÂU 2:
-- Cài đặt cơ sở dữ liệu và thiết lập tài khoản theo mô tả TC#1
-- ==========================================================

-- ==========================================================
-- PHẦN 1. THIẾT LẬP BAN ĐẦU - CHẠY BẰNG SYSDBA
-- ==========================================================

SET SERVEROUTPUT ON;
SET SQLBLANKLINES ON;
SET VERIFY OFF

-- =====================================================================
-- Nhap mat khau cua SYS MOT LAN. Cac buoc "CONNECT SYS ... AS SYSDBA"
-- ben duoi se tu dung lai gia tri nay -> chay het script trong 1 lan,
-- khong bi loi ORA-01017 do mat khau SYS khac '123'.
-- (Mat khau cac tai khoan khac nhu adminHos do CHINH script tao = "123".)
-- =====================================================================
SET DEFINE ON
ACCEPT SYS_PWD CHAR PROMPT 'Nhap mat khau cua SYS (de ket noi lai AS SYSDBA): ' HIDE

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
-- 2. ĐẢM BẢO USER QUẢN TRỊ adminHos, admin_ph1, admin_ph2 TỒN TẠI
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

    -- Kiểm tra user admin_ph1 đã tồn tại chưa
    SELECT COUNT(*)
    INTO v_count
    FROM DBA_USERS
    WHERE USERNAME = 'ADMIN_PH1';

    IF v_count = 0 THEN
        EXECUTE IMMEDIATE 'CREATE USER admin_ph1 IDENTIFIED BY "123" ACCOUNT UNLOCK';
    ELSE
        EXECUTE IMMEDIATE 'ALTER USER admin_ph1 IDENTIFIED BY "123" ACCOUNT UNLOCK';
    END IF;

    -- Kiểm tra user admin_ph2 đã tồn tại chưa
    SELECT COUNT(*)
    INTO v_count
    FROM DBA_USERS
    WHERE USERNAME = 'ADMIN_PH2';

    IF v_count = 0 THEN
        EXECUTE IMMEDIATE 'CREATE USER admin_ph2 IDENTIFIED BY "123" ACCOUNT UNLOCK';
    ELSE
        EXECUTE IMMEDIATE 'ALTER USER admin_ph2 IDENTIFIED BY "123" ACCOUNT UNLOCK';
    END IF;
END;
/


-- ==========================================================
-- 3. CẤP QUYỀN CHO adminHos, admin_ph1, admin_ph2
-- ==========================================================

GRANT DBA TO adminHos;
GRANT CREATE SESSION TO adminHos;
GRANT DBA TO admin_ph1;
GRANT CREATE SESSION TO admin_ph1;
GRANT DBA TO admin_ph2;
GRANT CREATE SESSION TO admin_ph2;

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

-- Cap quyen truc tiep de stored procedures (Definer's Rights) cua adminHos co the truy cap
GRANT SELECT ON DBA_USERS TO adminHos;
GRANT SELECT ON DBA_AUDIT_TRAIL TO adminHos;
GRANT SELECT ON DBA_FGA_AUDIT_TRAIL TO adminHos;
GRANT SELECT ON V_$BACKUP_SET TO adminHos;

-- Chuyển sang user quản trị ứng dụng
CONN adminHos/123@localhost:1521/PDBHOSX
SHOW USER;
SHOW CON_NAME;

-- ==========================================================
-- PHẦN 2. CÀI ĐẶT CSDL Y TẾ VÀ TÀI KHOẢN THEO TC#1
-- ==========================================================

SET SERVEROUTPUT ON;
SET SQLBLANKLINES ON;

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
    CCCD            VARCHAR2(20)    UNIQUE NOT NULL,
    SONHA           NVARCHAR2(50)   NOT NULL,
    TENDUONG        NVARCHAR2(100)  NOT NULL,
    QUANHUYEN       NVARCHAR2(50)   NOT NULL,
    TINHTP          NVARCHAR2(50)   NOT NULL,
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
    CMND            VARCHAR2(20)    UNIQUE NOT NULL,
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
    COSO            NVARCHAR2(100),

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
        FOREIGN KEY (MAKTV) REFERENCES NHANVIEN(MANV),

    CONSTRAINT CK_HSBADV_KTV_KETQUA
        CHECK (MAKTV IS NOT NULL OR KETQUA IS NULL OR KETQUA = N'Chưa có kết quả')
);


CREATE OR REPLACE TRIGGER ADMINHOS.TRG_DELETE_HSBA_DV_MAKTV
BEFORE DELETE ON ADMINHOS.HSBA_DV
FOR EACH ROW
BEGIN
    IF :OLD.MAKTV IS NOT NULL THEN
        RAISE_APPLICATION_ERROR(-20001, 'Không thể xóa dịch vụ đã được phân công kỹ thuật viên.');
    END IF;
END;
/


CREATE TABLE DONTHUOC (
    MAHSBA          VARCHAR2(10)    NOT NULL,
    NGAYDT          DATE            NOT NULL,
    TENTHUOC        NVARCHAR2(100)  NOT NULL,
    LIEUDUNG        NVARCHAR2(100)  NOT NULL,

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
    MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO
)
SELECT
    'HSBA' || LPAD(L.LVL, 5, '0'),
    'BN' || LPAD(L.LVL, 6, '0'),
    DATE '2026-05-01' + L.LVL,
    N'Chẩn đoán ban đầu ' || TO_NCHAR(L.LVL),
    N'Hướng điều trị ' || TO_NCHAR(L.LVL),
    'BS' || LPAD(MOD(L.LVL - 1, 100) + 1, 4, '0'),
    CASE MOD(L.LVL + FLOOR((L.LVL - 1) / 3), 3)
        WHEN 0 THEN 'KTH' --khoa tiêu hóa
        WHEN 1 THEN 'KTK' --khoa thần kinh
        ELSE 'KTM'  --khoa tim mạch
    END,
    N'Đang theo dõi',
    NV.COSO
FROM (
    SELECT LEVEL AS LVL FROM DUAL CONNECT BY LEVEL <= 100
) L
LEFT JOIN NHANVIEN NV ON NV.MANV = 'BS' || LPAD(MOD(L.LVL - 1, 100) + 1, 4, '0');


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


-- Tại đây 
-- Chèn 10 HSBA cho BS0001
INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00101', 'BN000001', TO_DATE('2026-06-01', 'YYYY-MM-DD'), N'Đau dạ dày cấp', N'Uống thuốc dạ dày', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00102', 'BN000002', TO_DATE('2026-06-02', 'YYYY-MM-DD'), N'Rối loạn tiêu hóa', N'Kháng sinh và men tiêu hóa', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00103', 'BN000003', TO_DATE('2026-06-03', 'YYYY-MM-DD'), N'Trào ngược dạ dày', N'Uống thuốc kháng acid', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00104', 'BN000004', TO_DATE('2026-06-04', 'YYYY-MM-DD'), N'Viêm đại tràng', N'Chế độ ăn kiêng và kháng sinh', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00105', 'BN000005', TO_DATE('2026-06-05', 'YYYY-MM-DD'), N'Đau bụng chưa rõ nguyên nhân', N'Theo dõi lâm sàng', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00106', 'BN000006', TO_DATE('2026-06-06', 'YYYY-MM-DD'), N'Ngộ độc thực phẩm', N'Truyền dịch', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00107', 'BN000007', TO_DATE('2026-06-07', 'YYYY-MM-DD'), N'Viêm dạ dày mãn tính', N'Điều trị kết hợp', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00108', 'BN000008', TO_DATE('2026-06-08', 'YYYY-MM-DD'), N'Loét dạ dày tá tràng', N'Phác đồ diệt HP', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00109', 'BN000009', TO_DATE('2026-06-09', 'YYYY-MM-DD'), N'Hội chứng ruột kích thích', N'Điều chỉnh lối sống', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

INSERT INTO HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO)
VALUES ('HSBA00110', 'BN000010', TO_DATE('2026-06-10', 'YYYY-MM-DD'), N'Xuất huyết tiêu hóa nhẹ', N'Nội soi can thiệp', 'BS0001', 'KTH', N'Đang theo dõi', N'Hồ Chí Minh');

-- 2 đơn thuốc cho mỗi HSBA từ HSBA00101 đến HSBA00110
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00101', TO_DATE('2026-06-01', 'YYYY-MM-DD'), N'Paracetamol 500mg', N'Ngày 2 lần, mỗi lần 1 viên');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00101', TO_DATE('2026-06-01', 'YYYY-MM-DD'), N'Omeprazole 20mg', N'Ngày 1 lần trước ăn sáng');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00102', TO_DATE('2026-06-02', 'YYYY-MM-DD'), N'Amoxicillin 500mg', N'Ngày 3 lần, mỗi lần 1 viên');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00102', TO_DATE('2026-06-02', 'YYYY-MM-DD'), N'Enterogermina', N'Ngày uống 2 ống');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00103', TO_DATE('2026-06-03', 'YYYY-MM-DD'), N'Gaviscon', N'Uống 1 gói sau ăn');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00103', TO_DATE('2026-06-03', 'YYYY-MM-DD'), N'Esomeprazole 40mg', N'Ngày 1 viên trước ăn sáng');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00104', TO_DATE('2026-06-04', 'YYYY-MM-DD'), N'Metronidazole 250mg', N'Ngày 3 lần, mỗi lần 1 viên');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00104', TO_DATE('2026-06-04', 'YYYY-MM-DD'), N'Loperamide 2mg', N'Uống khi tiêu chảy');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00105', TO_DATE('2026-06-05', 'YYYY-MM-DD'), N'Drotaverine 40mg', N'Ngày 2 lần, mỗi lần 1 viên');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00105', TO_DATE('2026-06-05', 'YYYY-MM-DD'), N'Pancreatin', N'Ngày 3 lần uống trong bữa ăn');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00106', TO_DATE('2026-06-06', 'YYYY-MM-DD'), N'Oresol', N'Pha 1 gói uống cả ngày');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00106', TO_DATE('2026-06-06', 'YYYY-MM-DD'), N'Ciprofloxacin 500mg', N'Ngày 2 lần, mỗi lần 1 viên');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00107', TO_DATE('2026-06-07', 'YYYY-MM-DD'), N'Rabeprazole 20mg', N'Ngày 1 lần trước ăn sáng');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00107', TO_DATE('2026-06-07', 'YYYY-MM-DD'), N'Phosphalugel', N'Uống khi đau dạ dày');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00108', TO_DATE('2026-06-08', 'YYYY-MM-DD'), N'Clarithromycin 500mg', N'Ngày 2 lần, mỗi lần 1 viên');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00108', TO_DATE('2026-06-08', 'YYYY-MM-DD'), N'Pantoprazole 40mg', N'Ngày 1 lần trước ăn sáng');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00109', TO_DATE('2026-06-09', 'YYYY-MM-DD'), N'Mebeverine 200mg', N'Ngày 2 lần, trước ăn 20 phút');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00109', TO_DATE('2026-06-09', 'YYYY-MM-DD'), N'Probiotics', N'Ngày 1 gói uống buổi tối');

INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00110', TO_DATE('2026-06-10', 'YYYY-MM-DD'), N'Tranexamic acid 500mg', N'Ngày 3 lần, mỗi lần 1 viên');
INSERT INTO DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG) VALUES ('HSBA00110', TO_DATE('2026-06-10', 'YYYY-MM-DD'), N'Lansoprazole 30mg', N'Ngày 1 lần trước ăn sáng');

COMMIT;
-- Kết thúc

-- ==========================================================
-- PHẦN 3. TẠO VIEW VÀ ROLE RBAC CHO KỸ THUẬT VIÊN VÀ BỆNH NHÂN
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

    -- Kiểm tra xem người dùng có thay đổi các cột không được phép hay không
    IF :NEW.MANV != :OLD.MANV THEN
        RAISE_APPLICATION_ERROR(-20010, 'Chinh sach bao mat: Khong duoc phep cap nhat ma nhan vien');
    END IF;
    IF :NEW.HOTEN != :OLD.HOTEN THEN
        RAISE_APPLICATION_ERROR(-20011, 'Chinh sach bao mat: Khong duoc phep cap nhat ho ten nhan vien');
    END IF;
    IF :NEW.PHAI != :OLD.PHAI THEN
        RAISE_APPLICATION_ERROR(-20012, 'Chinh sach bao mat: Khong duoc phep cap nhat phai (gioi tinh)');
    END IF;
    IF :NEW.NGAYSINH != :OLD.NGAYSINH THEN
        RAISE_APPLICATION_ERROR(-20013, 'Chinh sach bao mat: Khong duoc phep cap nhat ngay sinh');
    END IF;
    IF :NEW.CMND != :OLD.CMND THEN
        RAISE_APPLICATION_ERROR(-20014, 'Chinh sach bao mat: Khong duoc phep cap nhat CMND/CCCD');
    END IF;
    IF :NEW.VAITRO != :OLD.VAITRO THEN
        RAISE_APPLICATION_ERROR(-20015, 'Chinh sach bao mat: Khong duoc phep cap nhat vai tro');
    END IF;
    -- DECODE không dùng được trong PL/SQL IF — dùng NVL để so sánh NULL-safe
    IF NVL(:NEW.CHUYENKHOA, '<<NULL>>') != NVL(:OLD.CHUYENKHOA, '<<NULL>>') THEN
        RAISE_APPLICATION_ERROR(-20016, 'Chinh sach bao mat: Khong duoc phep cap nhat chuyen khoa');
    END IF;
    IF NVL(:NEW.COSO, '<<NULL>>') != NVL(:OLD.COSO, '<<NULL>>') THEN
        RAISE_APPLICATION_ERROR(-20017, 'Chinh sach bao mat: Khong duoc phep cap nhat co so lam viec');
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

    -- Kiểm tra nếu người dùng cố ý cập nhật các trường không được phép
    IF :NEW.MABN != :OLD.MABN THEN
        RAISE_APPLICATION_ERROR(-20020, 'Chinh sach bao mat: Khong duoc phep cap nhat ma benh nhan');
    END IF;
    IF :NEW.TENBN != :OLD.TENBN THEN
        RAISE_APPLICATION_ERROR(-20021, 'Chinh sach bao mat: Khong duoc phep cap nhat ho ten benh nhan');
    END IF;
    IF :NEW.PHAI != :OLD.PHAI THEN
        RAISE_APPLICATION_ERROR(-20022, 'Chinh sach bao mat: Khong duoc phep cap nhat phai (gioi tinh) benh nhan');
    END IF;
    IF :NEW.NGAYSINH != :OLD.NGAYSINH THEN
        RAISE_APPLICATION_ERROR(-20023, 'Chinh sach bao mat: Khong duoc phep cap nhat ngay sinh benh nhan');
    END IF;
    IF :NEW.CCCD != :OLD.CCCD THEN
        RAISE_APPLICATION_ERROR(-20024, 'Chinh sach bao mat: Khong duoc phep cap nhat CCCD benh nhan');
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
        policy_name   => 'VPD_YC1C3_HSBA_SEL_DPV'
    );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA',
        policy_name   => 'VPD_YC1C3_HSBA_UPD_DPV'
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

-- Create context for VPD bypass
BEGIN
    EXECUTE IMMEDIATE 'DROP CONTEXT HSBA_BYPASS_CTX';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/
CREATE CONTEXT HSBA_BYPASS_CTX USING ADMINHOS.PKG_VPD_YC1C3;
/

CREATE OR REPLACE PACKAGE ADMINHOS.PKG_VPD_YC1C3 AS

    -- ================================================================
    -- Policy cho Điều phối viên
    -- ================================================================
    FUNCTION FN_BENHNHAN_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;

    FUNCTION FN_HSBA_SEL_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2;

    FUNCTION FN_HSBA_UPD_DPV(
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

    FUNCTION FN_GET_NEXT_HSBA_ID RETURN VARCHAR2;

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


    FUNCTION FN_HSBA_SEL_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        -- Check if we should bypass this policy (e.g. when generating next sequence ID)
        IF SYS_CONTEXT('HSBA_BYPASS_CTX', 'BYPASS_VPD') = 'TRUE' THEN
            RETURN NULL;
        END IF;

        IF IS_DPV THEN
            -- Điều phối viên chỉ xem được HSBA thuộc cùng chi nhánh/cơ sở của mình
            RETURN 'COSO = (
                SELECT DP.COSO
                FROM ADMINHOS.NHANVIEN DP
                WHERE DP.MANV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                  AND DP.VAITRO = N''Điều phối viên''
            )';
        END IF;

        RETURN NULL;
    END FN_HSBA_SEL_DPV;


    FUNCTION FN_HSBA_UPD_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_DPV THEN
            -- Chỉ cho phép cập nhật HSBA thuộc cùng chi nhánh/cơ sở của mình
            RETURN 'COSO = (
                SELECT DP.COSO
                FROM ADMINHOS.NHANVIEN DP
                WHERE DP.MANV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                  AND DP.VAITRO = N''Điều phối viên''
            )';
        END IF;

        RETURN NULL;
    END FN_HSBA_UPD_DPV;


    FUNCTION FN_HSBADV_DPV(
        p_schema IN VARCHAR2,
        p_object IN VARCHAR2
    ) RETURN VARCHAR2 AS
    BEGIN
        IF IS_DPV THEN
            -- Điều phối viên chỉ được xem HSBA_DV có KTV thuộc cùng cơ sở (hoặc chưa phân công KTV)
            RETURN 'MAKTV IS NULL OR MAKTV IN (
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


    FUNCTION FN_GET_NEXT_HSBA_ID RETURN VARCHAR2 AS
        v_max NUMBER;
    BEGIN
        -- Set bypass context
        DBMS_SESSION.SET_CONTEXT('HSBA_BYPASS_CTX', 'BYPASS_VPD', 'TRUE');
        
        SELECT NVL(MAX(TO_NUMBER(SUBSTR(MAHSBA, 5))), 0) + 1 INTO v_max
        FROM ADMINHOS.HSBA
        WHERE MAHSBA LIKE 'HSBA%';
        
        -- Clear bypass context
        DBMS_SESSION.SET_CONTEXT('HSBA_BYPASS_CTX', 'BYPASS_VPD', 'FALSE');
        
        RETURN 'HSBA' || LPAD(TO_CHAR(v_max), 5, '0');
    EXCEPTION
        WHEN OTHERS THEN
            DBMS_SESSION.SET_CONTEXT('HSBA_BYPASS_CTX', 'BYPASS_VPD', 'FALSE');
            RAISE;
    END FN_GET_NEXT_HSBA_ID;

END PKG_VPD_YC1C3;
/

SHOW ERRORS PACKAGE BODY ADMINHOS.PKG_VPD_YC1C3;

GRANT EXECUTE ON ADMINHOS.PKG_VPD_YC1C3 TO public;


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
        policy_name     => 'VPD_YC1C3_HSBA_SEL_DPV',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_HSBA_SEL_DPV',
        statement_types => 'SELECT, INSERT',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINHOS',
        object_name     => 'HSBA',
        policy_name     => 'VPD_YC1C3_HSBA_UPD_DPV',
        function_schema => 'ADMINHOS',
        policy_function => 'PKG_VPD_YC1C3.FN_HSBA_UPD_DPV',
        statement_types => 'UPDATE',
        update_check    => TRUE,
        enable          => TRUE
    );

    DBMS_OUTPUT.PUT_LINE('OK: Da tao policies VPD_YC1C3_HSBA_SEL_DPV va VPD_YC1C3_HSBA_UPD_DPV');
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
  AND NV.COSO = (
        SELECT DP.COSO
        FROM ADMINHOS.NHANVIEN DP
        WHERE DP.MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')
          AND DP.VAITRO = N'Điều phối viên'
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


-- =====================================================================
-- PHÂN HỆ 2 - YÊU CẦU 2
-- CƠ CHẾ PHÁT TÁN THÔNG BÁO DÙNG ORACLE LABEL SECURITY
-- Schema: ADMINHOS
-- PDB: PDBHOSX
-- BẢN CUỐI: KHÔNG DÙNG PUBLIC SYNONYM, KHÔNG CỘT GHICHU (BẢN ROBUST FALLBACK)
-- =====================================================================

SET SERVEROUTPUT ON;

-- =====================================================================
-- PHẦN 1. CHẠY BẰNG SYS AS SYSDBA
-- Mục đích:
-- 1. Chuyển vào PDBHOSX
-- 2. Dọn sạch các object/policy/role cũ
-- 3. Cấp quyền cần thiết cho ADMINHOS
-- =====================================================================

SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF

ALTER SESSION SET CONTAINER = PDBHOSX;

-- Kiểm tra Oracle Label Security
SELECT VALUE
FROM V$OPTION
WHERE PARAMETER = 'Oracle Label Security';

SELECT COMP_NAME, STATUS
FROM DBA_REGISTRY
WHERE COMP_ID = 'OLS';

-- Mở khóa và reset LBACSYS
BEGIN
    EXECUTE IMMEDIATE 'ALTER USER LBACSYS IDENTIFIED BY lbacsys123 ACCOUNT UNLOCK';
EXCEPTION
    WHEN OTHERS THEN
        BEGIN
            EXECUTE IMMEDIATE 'ALTER USER LBACSYS ACCOUNT UNLOCK';
        EXCEPTION WHEN OTHERS THEN NULL;
        END;
END;
/

-- -------------------------------------------------------
-- Cố gắng bật Oracle Label Security nếu chưa bật
-- Oracle 21c XE đã tích hợp OLS sẵn — chỉ cần kích hoạt
-- -------------------------------------------------------
DECLARE
    v_ols VARCHAR2(10) := 'FALSE';
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN v_ols := 'UNKNOWN';
    END;
    DBMS_OUTPUT.PUT_LINE('>>> Oracle Label Security (V$OPTION): ' || v_ols);

    IF v_ols != 'TRUE' THEN
        -- Thử kích hoạt OLS qua package nội bộ của LBACSYS
        BEGIN
            EXECUTE IMMEDIATE 'BEGIN LBACSYS.LBAC_ADMIN.ACTIVATE; END;';
            DBMS_OUTPUT.PUT_LINE('>>> OLS da duoc kich hoat thanh cong.');
        EXCEPTION WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('>>> OLS khong the tu dong kich hoat: ' || SQLERRM);
            DBMS_OUTPUT.PUT_LINE('>>> Script se dung fallback mode (luu label trong VARCHAR2).');
        END;
    ELSE
        DBMS_OUTPUT.PUT_LINE('>>> OLS san sang, khong can bat them.');
    END IF;
END;
/

-- Grant quyền SELECT V$OPTION cho ADMINHOS để check OLS status
GRANT SELECT ON V_$OPTION TO ADMINHOS;

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
    EXECUTE IMMEDIATE '
    BEGIN
        SA_POLICY_ADMIN.REMOVE_TABLE_POLICY(
            policy_name => ''THONGBAO_OLS'',
            schema_name => ''ADMINHOS'',
            table_name  => ''THONGBAO'',
            drop_column => TRUE
        );
    END;';
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
    EXECUTE IMMEDIATE '
    BEGIN
        SA_SYSDBA.DROP_POLICY(
            policy_name => ''THONGBAO_OLS'',
            drop_column => TRUE
        );
    END;';
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

SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF
ALTER SESSION SET CONTAINER = PDBHOSX;

-- Cấp quyền dùng các package OLS cho ADMINHOS
BEGIN
    EXECUTE IMMEDIATE 'GRANT EXECUTE ON LBACSYS.SA_SYSDBA       TO ADMINHOS';
    EXECUTE IMMEDIATE 'GRANT EXECUTE ON LBACSYS.SA_COMPONENTS   TO ADMINHOS';
    EXECUTE IMMEDIATE 'GRANT EXECUTE ON LBACSYS.SA_LABEL_ADMIN  TO ADMINHOS';
    EXECUTE IMMEDIATE 'GRANT EXECUTE ON LBACSYS.SA_POLICY_ADMIN TO ADMINHOS';
    EXECUTE IMMEDIATE 'GRANT EXECUTE ON LBACSYS.SA_USER_ADMIN   TO ADMINHOS';
    EXECUTE IMMEDIATE 'GRANT EXECUTE ON LBACSYS.SA_SESSION      TO ADMINHOS';
    EXECUTE IMMEDIATE 'GRANT LBAC_DBA TO ADMINHOS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

-- =====================================================================
-- PHẦN 2. CHẠY BẰNG ADMINHOS
-- Tạo bảng THONGBAO và tạo OLS policy
-- =====================================================================
CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;

-- Tạo bảng THONGBAO
CREATE TABLE THONGBAO (
    MATB        VARCHAR2(10) PRIMARY KEY,
    NOIDUNG     NVARCHAR2(500) NOT NULL,
    NGAYGIO     TIMESTAMP DEFAULT SYSTIMESTAMP NOT NULL,
    DIADIEM     NVARCHAR2(100)
);

-- BỔ SUNG ROBUST FALLBACK CHO OLS
DECLARE
    v_ols_enabled VARCHAR2(10) := 'FALSE';
    v_count NUMBER;
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols_enabled FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN
        v_ols_enabled := 'FALSE';
    END;

    IF v_ols_enabled = 'TRUE' THEN
        -- Real OLS Policy creation
        BEGIN
            EXECUTE IMMEDIATE '
            BEGIN
                SA_SYSDBA.CREATE_POLICY(
                    policy_name     => ''THONGBAO_OLS'',
                    column_name     => ''OLS_LABEL'',
                    default_options => ''READ_CONTROL,WRITE_CONTROL,CHECK_CONTROL''
                );
            END;';
            DBMS_OUTPUT.PUT_LINE('Da tao policy THONGBAO_OLS.');
        EXCEPTION WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('Loi tao policy OLS: ' || SQLERRM);
        END;
    ELSE
        DBMS_OUTPUT.PUT_LINE('OLS is disabled. Creating dummy OLS column and helper functions.');
        
        -- Add OLS_LABEL column manually
        SELECT COUNT(*) INTO v_count FROM USER_TAB_COLUMNS WHERE TABLE_NAME = 'THONGBAO' AND COLUMN_NAME = 'OLS_LABEL';
        IF v_count = 0 THEN
            EXECUTE IMMEDIATE 'ALTER TABLE THONGBAO ADD (OLS_LABEL VARCHAR2(4000))';
        END IF;

        -- Create dummy CHAR_TO_LABEL
        EXECUTE IMMEDIATE '
        CREATE OR REPLACE FUNCTION CHAR_TO_LABEL(policy_name VARCHAR2, label_string VARCHAR2) RETURN VARCHAR2 AS
        BEGIN
            RETURN label_string;
        END;';

        -- Create dummy LABEL_TO_CHAR
        EXECUTE IMMEDIATE '
        CREATE OR REPLACE FUNCTION LABEL_TO_CHAR(label_val VARCHAR2) RETURN VARCHAR2 AS
        BEGIN
            RETURN label_val;
        END;';
    END IF;
END;
/

-- =====================================================================
-- PHẦN 3. QUAY LẠI SYSDBA
-- Đảm bảo role THONGBAO_OLS_DBA luôn tồn tại và cấp cho ADMINHOS
-- =====================================================================
SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF
ALTER SESSION SET CONTAINER = PDBHOSX;

DECLARE
    v_ols_enabled VARCHAR2(10) := 'FALSE';
    v_count NUMBER;
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols_enabled FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN
        v_ols_enabled := 'FALSE';
    END;

    -- Nếu OLS không bật, tạo Role ảo THONGBAO_OLS_DBA để tránh lỗi khi SET ROLE
    IF v_ols_enabled != 'TRUE' THEN
        SELECT COUNT(*) INTO v_count FROM DBA_ROLES WHERE ROLE = 'THONGBAO_OLS_DBA';
        IF v_count = 0 THEN
            EXECUTE IMMEDIATE 'CREATE ROLE THONGBAO_OLS_DBA';
        END IF;
    END IF;
    
    EXECUTE IMMEDIATE 'GRANT THONGBAO_OLS_DBA TO ADMINHOS';
EXCEPTION WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('Loi cap role: ' || SQLERRM);
END;
/

-- =====================================================================
-- PHẦN 4. QUAY LẠI ADMINHOS
-- Bật role policy và tạo LEVEL / COMPARTMENT / GROUP
-- =====================================================================
CONNECT adminHos/123@localhost:1521/PDBHOSX

SET SERVEROUTPUT ON;
SET ROLE THONGBAO_OLS_DBA;

-- 4.1. TẠO LEVEL / COMPARTMENT / GROUP dynamically
DECLARE
    v_ols_enabled VARCHAR2(10) := 'FALSE';
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols_enabled FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN
        v_ols_enabled := 'FALSE';
    END;

    IF v_ols_enabled = 'TRUE' THEN
        -- Define Levels
        BEGIN
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_LEVEL(''THONGBAO_OLS'', 10, ''NV'', ''Nhan vien''); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_LEVEL(''THONGBAO_OLS'', 20, ''LDK'', ''Lanh dao khoa''); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_LEVEL(''THONGBAO_OLS'', 30, ''BGD'', ''Ban giam doc''); END;';
            DBMS_OUTPUT.PUT_LINE('Da tao LEVEL: NV, LDK, BGD.');
        EXCEPTION WHEN OTHERS THEN DBMS_OUTPUT.PUT_LINE('Loi tao level: ' || SQLERRM);
        END;

        -- Define Compartments
        BEGIN
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_COMPARTMENT(''THONGBAO_OLS'', 10, ''TH'', ''Khoa tieu hoa''); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_COMPARTMENT(''THONGBAO_OLS'', 20, ''TK'', ''Khoa than kinh''); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_COMPARTMENT(''THONGBAO_OLS'', 30, ''TM'', ''Khoa tim mach''); END;';
            DBMS_OUTPUT.PUT_LINE('Da tao COMPARTMENT: TH, TK, TM.');
        EXCEPTION WHEN OTHERS THEN DBMS_OUTPUT.PUT_LINE('Loi tao compartment: ' || SQLERRM);
        END;

        -- Define Groups
        BEGIN
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_GROUP(''THONGBAO_OLS'', 10, ''HCM'', ''Ho Chi Minh''); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_GROUP(''THONGBAO_OLS'', 20, ''HP'', ''Hai Phong''); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_COMPONENTS.CREATE_GROUP(''THONGBAO_OLS'', 30, ''HN'', ''Ha Noi''); END;';
            DBMS_OUTPUT.PUT_LINE('Da tao GROUP: HCM, HP, HN.');
        EXCEPTION WHEN OTHERS THEN DBMS_OUTPUT.PUT_LINE('Loi tao group: ' || SQLERRM);
        END;
    ELSE
        DBMS_OUTPUT.PUT_LINE('OLS is disabled. Skipping Levels, Compartments, Groups.');
    END IF;
END;
/

-- =====================================================================
-- PHẦN 5. TẠO DATA LABEL CHO CÁC THÔNG BÁO T1..T7
-- =====================================================================
DECLARE
    v_ols_enabled VARCHAR2(10) := 'FALSE';
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols_enabled FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN
        v_ols_enabled := 'FALSE';
    END;

    IF v_ols_enabled = 'TRUE' THEN
        BEGIN
            EXECUTE IMMEDIATE 'BEGIN SA_LABEL_ADMIN.CREATE_LABEL(''THONGBAO_OLS'', 101, ''NV'', TRUE); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_LABEL_ADMIN.CREATE_LABEL(''THONGBAO_OLS'', 102, ''BGD'', TRUE); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_LABEL_ADMIN.CREATE_LABEL(''THONGBAO_OLS'', 103, ''LDK'', TRUE); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_LABEL_ADMIN.CREATE_LABEL(''THONGBAO_OLS'', 104, ''LDK:TH'', TRUE); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_LABEL_ADMIN.CREATE_LABEL(''THONGBAO_OLS'', 105, ''NV:TH:HCM'', TRUE); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_LABEL_ADMIN.CREATE_LABEL(''THONGBAO_OLS'', 106, ''NV:TH:HN'', TRUE); END;';
            EXECUTE IMMEDIATE 'BEGIN SA_LABEL_ADMIN.CREATE_LABEL(''THONGBAO_OLS'', 107, ''LDK:TH,TK:HP'', TRUE); END;';
            DBMS_OUTPUT.PUT_LINE('Da tao OLS DATA LABEL.');
        EXCEPTION WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('Loi tao OLS labels: ' || SQLERRM);
        END;
    ELSE
        DBMS_OUTPUT.PUT_LINE('OLS is disabled. Skipping OLS labels creation.');
    END IF;
END;
/

-- =====================================================================
-- PHẦN 6. ÁP POLICY VÀO BẢNG THONGBAO
-- =====================================================================
DECLARE
    v_ols_enabled VARCHAR2(10) := 'FALSE';
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols_enabled FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN
        v_ols_enabled := 'FALSE';
    END;

    IF v_ols_enabled = 'TRUE' THEN
        BEGIN
            EXECUTE IMMEDIATE '
            BEGIN
                SA_POLICY_ADMIN.APPLY_TABLE_POLICY(
                    policy_name    => ''THONGBAO_OLS'',
                    schema_name    => ''ADMINHOS'',
                    table_name     => ''THONGBAO'',
                    table_options  => ''READ_CONTROL,WRITE_CONTROL,CHECK_CONTROL'',
                    label_function => NULL,
                    predicate      => NULL
                );
            END;';
            DBMS_OUTPUT.PUT_LINE('Da apply policy vao ADMINHOS.THONGBAO.');
        EXCEPTION WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('Loi apply table policy: ' || SQLERRM);
        END;
    ELSE
        DBMS_OUTPUT.PUT_LINE('OLS is disabled. Skipping table policy application.');
    END IF;
END;
/

-- =====================================================================
-- PHẦN 7. GÁN FULL OLS CHO ADMINHOS ĐỂ NHẬP DỮ LIỆU
-- =====================================================================
DECLARE
    v_ols_enabled VARCHAR2(10) := 'FALSE';
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols_enabled FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN
        v_ols_enabled := 'FALSE';
    END;

    IF v_ols_enabled = 'TRUE' THEN
        BEGIN
            EXECUTE IMMEDIATE '
            BEGIN
                SA_USER_ADMIN.SET_USER_LABELS(
                    policy_name     => ''THONGBAO_OLS'',
                    user_name       => ''ADMINHOS'',
                    max_read_label  => ''BGD:TH,TK,TM:HCM,HP,HN'',
                    max_write_label => ''BGD:TH,TK,TM:HCM,HP,HN'',
                    min_write_label => ''NV'',
                    def_label       => ''BGD:TH,TK,TM:HCM,HP,HN'',
                    row_label       => ''BGD:TH,TK,TM:HCM,HP,HN''
                );
                
                SA_USER_ADMIN.SET_USER_PRIVS(
                    policy_name => ''THONGBAO_OLS'',
                    user_name   => ''ADMINHOS'',
                    privileges  => ''FULL''
                );
            END;';
            DBMS_OUTPUT.PUT_LINE('Da gan FULL OLS cho ADMINHOS.');
        EXCEPTION WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('Loi gan user labels cho ADMINHOS: ' || SQLERRM);
        END;
    ELSE
        DBMS_OUTPUT.PUT_LINE('OLS is disabled. Skipping user labels for ADMINHOS.');
    END IF;
END;
/

COMMIT;

-- Login lại để session ADMINHOS nhận quyền OLS mới (nếu có)
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
DECLARE
    v_ols_enabled VARCHAR2(10) := 'FALSE';
    PROCEDURE SET_LABEL(u VARCHAR2, r VARCHAR2, w VARCHAR2, mn VARCHAR2, df VARCHAR2, rw VARCHAR2) IS
    BEGIN
        EXECUTE IMMEDIATE '
        BEGIN
            SA_USER_ADMIN.SET_USER_LABELS(
                policy_name     => ''THONGBAO_OLS'',
                user_name       => :1,
                max_read_label  => :2,
                max_write_label => :3,
                min_write_label => :4,
                def_label       => :5,
                row_label       => :6
            );
        END;' USING u, r, w, mn, df, rw;
    EXCEPTION WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Loi gan label cho ' || u || ': ' || SQLERRM);
    END;
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols_enabled FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN
        v_ols_enabled := 'FALSE';
    END;

    IF v_ols_enabled = 'TRUE' THEN
        SET_LABEL('U1', 'BGD:TH,TK,TM:HCM,HP,HN', 'BGD:TH,TK,TM:HCM,HP,HN', 'NV', 'BGD:TH,TK,TM:HCM,HP,HN', 'BGD:TH,TK,TM:HCM,HP,HN');
        SET_LABEL('U2', 'LDK:TM:HCM', 'LDK:TM:HCM', 'NV', 'LDK:TM:HCM', 'LDK:TM:HCM');
        SET_LABEL('U3', 'LDK:TK:HN', 'LDK:TK:HN', 'NV', 'LDK:TK:HN', 'LDK:TK:HN');
        SET_LABEL('U4', 'NV:TK:HCM', 'NV:TK:HCM', 'NV', 'NV:TK:HCM', 'NV:TK:HCM');
        SET_LABEL('U5', 'NV:TM:HCM', 'NV:TM:HCM', 'NV', 'NV:TM:HCM', 'NV:TM:HCM');
        SET_LABEL('U6', 'LDK:TM:HCM', 'LDK:TM:HCM', 'NV', 'LDK:TM:HCM', 'LDK:TM:HCM');
        SET_LABEL('U7', 'LDK:TH,TK,TM:HCM,HP,HN', 'LDK:TH,TK,TM:HCM,HP,HN', 'NV', 'LDK:TH,TK,TM:HCM,HP,HN', 'LDK:TH,TK,TM:HCM,HP,HN');
        SET_LABEL('U8', 'NV:TH:HN', 'NV:TH:HN', 'NV', 'NV:TH:HN', 'NV:TH:HN');
    ELSE
        DBMS_OUTPUT.PUT_LINE('OLS is disabled. Skipping OLS user labels for U1..U8.');
    END IF;
END;
/

-- =====================================================================
-- PHẦN 11. TẠO VIEW HỖ TRỢ GIAO DIỆN
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
-- =====================================================================
SET ROLE THONGBAO_OLS_DBA;

DECLARE
    v_comp  VARCHAR2(50);
    v_group VARCHAR2(50);
    v_label VARCHAR2(200);
    v_ols_enabled VARCHAR2(10) := 'FALSE';
BEGIN
    BEGIN
        SELECT VALUE INTO v_ols_enabled FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
    EXCEPTION WHEN OTHERS THEN
        v_ols_enabled := 'FALSE';
    END;

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
            CONTINUE;
        END IF;

        v_label := 'NV:' || v_comp || ':' || v_group;

        IF v_ols_enabled = 'TRUE' THEN
            BEGIN
                EXECUTE IMMEDIATE '
                BEGIN
                    SA_USER_ADMIN.SET_USER_LABELS(
                        policy_name     => ''THONGBAO_OLS'',
                        user_name       => :1,
                        max_read_label  => :2,
                        max_write_label => :3,
                        min_write_label => ''NV'',
                        def_label       => :4,
                        row_label       => :5
                    );
                END;' USING r.MANV, v_label, v_label, v_label, v_label;
            EXCEPTION
                WHEN OTHERS THEN NULL;
            END;
        END IF;

        -- Quyen select view luon luon duoc cap
        BEGIN
            EXECUTE IMMEDIATE
                'GRANT SELECT ON ADMINHOS.VW_THONGBAO_APP TO ' || r.MANV;
        EXCEPTION WHEN OTHERS THEN NULL;
        END;

    END LOOP;
    DBMS_OUTPUT.PUT_LINE('Hoan tat gan OLS cho nhan vien.');
END;
/

-- VẬN DỤNG CƠ CHẾ KIỂM TOÁN
-- ==========================================================

SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF

ALTER SESSION SET CONTAINER = PDBHOSX;

SET SERVEROUTPUT ON;


-- Kiểm tra chế độ audit hiện tại
SHOW PARAMETER audit_trail;

SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF

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

SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF

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


-- Policy mới cho UPDATE bất hợp pháp trên HSBA_DV
BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'FGA_HSBA_DV_UPDATE_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- Policy mới cho UPDATE MAKTV bất hợp pháp trên HSBA_DV
BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'FGA_HSBA_DV_UPDATE_MAKTV_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- Policy mới cho UPDATE KETQUA bất hợp pháp trên HSBA_DV
BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'FGA_HSBA_DV_UPDATE_KETQUA_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- Policy mới cho UPDATE các cột khác bất hợp pháp trên HSBA_DV
BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'FGA_HSBA_DV_UPDATE_OTHER_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- Policy mới cho DELETE bất hợp pháp trên HSBA_DV
BEGIN
    DBMS_FGA.DROP_POLICY(
        object_schema => 'ADMINHOS',
        object_name   => 'HSBA_DV',
        policy_name   => 'FGA_HSBA_DV_DELETE_BATHOPPHAP'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/


-- Hàm hỗ trợ FGA: kiểm tra user hiện tại có phải Bác sĩ/Y sĩ phụ trách HSBA không
CREATE OR REPLACE FUNCTION ADMINHOS.FN_FGA_IS_BS_PHUTRACH_HSBA (
    p_mahsba IN VARCHAR2
)
RETURN NUMBER
AS
    v_count NUMBER;
BEGIN
    SELECT COUNT(*)
    INTO v_count
    FROM ADMINHOS.HSBA H
    JOIN ADMINHOS.NHANVIEN NV
      ON NV.MANV = H.MABS
    WHERE H.MAHSBA = p_mahsba
      AND H.MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')
      AND NV.VAITRO = N'Bác sĩ/Y sĩ';

    IF v_count > 0 THEN
        RETURN 1;
    END IF;

    RETURN 0;
EXCEPTION
    WHEN OTHERS THEN
        RETURN 0;
END;
/

SHOW ERRORS FUNCTION ADMINHOS.FN_FGA_IS_BS_PHUTRACH_HSBA;

-- Hàm hỗ trợ FGA: kiểm tra user hiện tại có phải Điều phối viên không
CREATE OR REPLACE FUNCTION ADMINHOS.FN_FGA_IS_DPV
RETURN NUMBER
AS
    v_count NUMBER;
BEGIN
    SELECT COUNT(*)
    INTO v_count
    FROM ADMINHOS.NHANVIEN
    WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')
      AND VAITRO = N'Điều phối viên';

    IF v_count > 0 THEN
        RETURN 1;
    END IF;

    RETURN 0;
EXCEPTION
    WHEN OTHERS THEN
        RETURN 0;
END;
/

SHOW ERRORS FUNCTION ADMINHOS.FN_FGA_IS_DPV;



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
-- - Theo TC#3, Bác sĩ/Y sĩ được thêm dịch vụ cho HSBA mình phụ trách.
-- - INSERT bất hợp pháp khi user hiện tại không phải bác sĩ phụ trách HSBA đó.
-- - Để FGA ghi nhận được, trong phần test cần cấp quyền INSERT để câu lệnh
--   chạy tới bảng, sau đó FGA ghi nhận theo điều kiện nghiệp vụ.
-- ==========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA_DV',
        policy_name        => 'FGA_HSBA_DV_INSERT_BATHOPPHAP',
        audit_condition    => 'ADMINHOS.FN_FGA_IS_BS_PHUTRACH_HSBA(MAHSBA) = 0',
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
-- - Hợp pháp chỉ có 2 trường hợp:
--   + Điều phối viên cập nhật MAKTV để phân công kỹ thuật viên.
--   + Kỹ thuật viên cập nhật KETQUA trên dòng được phân công cho mình.
-- - Trường hợp bất hợp pháp: mọi UPDATE không thuộc 2 trường hợp trên đều audit.
-- - DELETE hợp pháp khi Bác sĩ/Y sĩ xóa dịch vụ thuộc HSBA mình phụ trách.
-- ==========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA_DV',
        policy_name        => 'FGA_HSBA_DV_UPDATE_MAKTV_BATHOPPHAP',
        audit_condition    => 'ADMINHOS.FN_FGA_IS_DPV() = 0',
        audit_column       => 'MAKTV',
        statement_types    => 'UPDATE',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
        audit_column_opts  => DBMS_FGA.ANY_COLUMNS
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_HSBA_DV_UPDATE_MAKTV_BATHOPPHAP');
END;
/

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA_DV',
        policy_name        => 'FGA_HSBA_DV_UPDATE_KETQUA_BATHOPPHAP',
        audit_condition    => 'SYS_CONTEXT(''USERENV'', ''SESSION_USER'') <> NVL(MAKTV, ''#'')',
        audit_column       => 'KETQUA',
        statement_types    => 'UPDATE',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
        audit_column_opts  => DBMS_FGA.ANY_COLUMNS
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_HSBA_DV_UPDATE_KETQUA_BATHOPPHAP');
END;
/

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA_DV',
        policy_name        => 'FGA_HSBA_DV_UPDATE_OTHER_BATHOPPHAP',
        audit_condition    => '1 = 1',
        audit_column       => 'MAHSBA,LOAIDV,NGAYDV',
        statement_types    => 'UPDATE',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
        audit_column_opts  => DBMS_FGA.ANY_COLUMNS
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_HSBA_DV_UPDATE_OTHER_BATHOPPHAP');
END;
/

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema      => 'ADMINHOS',
        object_name        => 'HSBA_DV',
        policy_name        => 'FGA_HSBA_DV_DELETE_BATHOPPHAP',
        audit_condition    => 'ADMINHOS.FN_FGA_IS_BS_PHUTRACH_HSBA(MAHSBA) = 0',
        audit_column       => NULL,
        statement_types    => 'DELETE',
        audit_trail        => DBMS_FGA.DB + DBMS_FGA.EXTENDED
    );

    DBMS_OUTPUT.PUT_LINE('Created policy FGA_HSBA_DV_DELETE_BATHOPPHAP');
END;
/


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

SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF

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
    BP.STATUS,
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

SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF

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

CREATE OR REPLACE PROCEDURE SP_RUN_DATAPUMP_BACKUP_DAILY AS
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
        job_action      => 'ADMINHOS.SP_RUN_DATAPUMP_BACKUP_DAILY',
        start_date      => TRUNC(SYSDATE + 1) + INTERVAL '2' HOUR,
        repeat_interval => 'FREQ=DAILY; BYHOUR=2; BYMINUTE=0; BYSECOND=0',
        enabled         => TRUE,
        comments        => 'Tu dong export schema ADMINHOS moi ngay luc 02:00'
    );
    DBMS_OUTPUT.PUT_LINE('Da tao Scheduler Job: JOB_DAILY_DATAPUMP_BACKUP');
END;
/
CONNECT ADMINHOS/123@localhost:1521/PDBHOSX 
SHOW USER

-- Xóa các SP nếu đã tồn tại
BEGIN
    FOR r IN (
        SELECT object_name, object_type 
        FROM user_objects 
        WHERE object_type IN ('PROCEDURE', 'FUNCTION')
          AND object_name IN (
              'SP_XEM_AUDIT_LOG', 'SP_GET_DASHBOARD_QTV', 'SP_GET_DASHBOARD_DPV', 'SP_GET_PATIENTS_NEED_ASSIGNMENT',
              'SP_GET_DASHBOARD_BS', 'SP_GET_RECENT_HSBA_THIS_MONTH', 'SP_GET_PRESCRIPTIONS_FOR_DOCTOR', 'SP_INSERT_DRUG',
              'SP_UPDATE_DRUG', 'SP_DELETE_DRUG', 'SP_GET_PROFILE', 'SP_GET_PROFILE_STATS', 'SP_UPDATE_PROFILE',
              'SP_GET_ALL_PATIENTS', 'SP_SEARCH_PATIENT', 'FN_GET_NEXT_PATIENT_ID', 'SP_INSERT_PATIENT', 'SP_UPDATE_PATIENT',
              'SP_GET_PATIENTS_FOR_DOCTOR', 'SP_UPDATE_PATIENT_HISTORY', 'SP_INSERT_HSBA', 'SP_GET_DOCTORS_FOR_TAOHSBA',
              'SP_GET_DEPARTMENTS', 'SP_GET_HSBA_FOR_DIEUPHOI', 'SP_UPDATE_HSBA_DEPT_DOC', 'SP_GET_HSBA_FOR_DOCTOR',
              'SP_GET_SERVICES_FOR_HSBA', 'SP_DELETE_HSBA_SERVICE', 'SP_GET_PRESCRIPTIONS_FOR_HSBA', 'SP_UPDATE_HSBA_DETAILS',
              'SP_INSERT_HSBA_SERVICE', 'SP_INSERT_DONTHUOC', 'SP_GET_HSBA_FOR_PATIENT', 'SP_GET_HSBA_DETAILS_BY_ID',
              'SP_GET_ALL_SERVICE_REQUESTS', 'SP_GET_ALL_TECHNICIANS', 'SP_ASSIGN_TECHNICIAN', 'SP_GET_NOTIFICATIONS'
          )
    ) LOOP
        EXECUTE IMMEDIATE 'DROP ' || r.object_type || ' ' || r.object_name;
    END LOOP;
END;
/

-- CÁC STORED PROCEDURE BỔ SUNG PHỤC VỤ APP

-- 1. Xem nhật ký kiểm toán
CREATE OR REPLACE PROCEDURE SP_XEM_AUDIT_LOG (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT *
    FROM (
        SELECT
            CAST('STANDARD' AS VARCHAR2(20)) AS LOAI_AUDIT,
            CAST(USERNAME AS VARCHAR2(128)) AS USER_NAME,
            CAST(OWNER AS VARCHAR2(128)) AS OWNER,
            CAST(OBJ_NAME AS VARCHAR2(128)) AS DOI_TUONG,
            CAST(ACTION_NAME AS VARCHAR2(50)) AS HANH_VI,
            CAST(NULL AS VARCHAR2(128)) AS POLICY_NAME,
            RETURNCODE AS MA_LOI,
            CAST(
                CASE
                    WHEN RETURNCODE = 0 THEN 'Thanh cong'
                    ELSE 'That bai'
                END AS VARCHAR2(50)
            ) AS KET_QUA,
            TIMESTAMP AS THOI_GIAN,
            CAST(NULL AS VARCHAR2(4000)) AS SQL_TEXT,
            CAST(ACTION_NAME || ' ON ' || OBJ_NAME AS VARCHAR2(4000)) AS CHI_TIET,
            CAST(TERMINAL AS VARCHAR2(128)) AS TERMINAL
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
        UNION ALL
        SELECT
            CAST('FGA' AS VARCHAR2(20)) AS LOAI_AUDIT,
            CAST(DB_USER AS VARCHAR2(128)) AS USER_NAME,
            CAST(OBJECT_SCHEMA AS VARCHAR2(128)) AS OWNER,
            CAST(OBJECT_NAME AS VARCHAR2(128)) AS DOI_TUONG,
            CAST(STATEMENT_TYPE AS VARCHAR2(50)) AS HANH_VI,
            CAST(POLICY_NAME AS VARCHAR2(128)) AS POLICY_NAME,
            0 AS MA_LOI,
            CAST(
                CASE
                    WHEN POLICY_NAME LIKE '%BATHOPPHAP%' THEN 'Canh bao'
                    ELSE 'Ghi nhan FGA'
                END AS VARCHAR2(50)
            ) AS KET_QUA,
            CAST(EXTENDED_TIMESTAMP AS DATE) AS THOI_GIAN,
            CAST(SUBSTR(SQL_TEXT, 1, 4000) AS VARCHAR2(4000)) AS SQL_TEXT,
            CAST(SUBSTR(SQL_TEXT, 1, 4000) AS VARCHAR2(4000)) AS CHI_TIET,
            CAST(USERHOST AS VARCHAR2(128)) AS TERMINAL
        FROM DBA_FGA_AUDIT_TRAIL
        WHERE OBJECT_SCHEMA = 'ADMINHOS'
          AND POLICY_NAME IN (
              'FGA_DONTHUOC_UPDATE',
              'FGA_HSBA_UPDATE_HOPPHAP',
              'FGA_HSBA_UPDATE_BATHOPPHAP',
              'FGA_HSBA_DV_INSERT_BATHOPPHAP',
              'FGA_HSBA_DV_UPDATE_MAKTV_BATHOPPHAP',
              'FGA_HSBA_DV_UPDATE_KETQUA_BATHOPPHAP',
              'FGA_HSBA_DV_UPDATE_OTHER_BATHOPPHAP',
              'FGA_HSBA_DV_DELETE_BATHOPPHAP'
          )
    )
    ORDER BY THOI_GIAN DESC;
END;
/

-- 2. Thống kê dashboard QTV
CREATE OR REPLACE PROCEDURE SP_GET_DASHBOARD_QTV (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT
        (SELECT COUNT(*) FROM ADMINHOS.NHANVIEN) + (SELECT COUNT(*) FROM ADMINHOS.BENHNHAN) AS ACTIVE_USERS,
        (SELECT COUNT(*) FROM DBA_AUDIT_TRAIL WHERE OWNER = 'ADMINHOS'
         AND OBJ_NAME IN ('HSBA', 'DONTHUOC', 'HSBA_DV', 'VW_NHANVIEN_SELF', 'VW_BENHNHAN_SELF', 'SP_CAPNHAT_KETLUAN_HSBA', 'FN_DEM_DONTHUOC')) +
        (SELECT COUNT(*) FROM DBA_FGA_AUDIT_TRAIL WHERE OBJECT_SCHEMA = 'ADMINHOS'
         AND POLICY_NAME IN ('FGA_DONTHUOC_UPDATE', 'FGA_HSBA_UPDATE_HOPPHAP', 'FGA_HSBA_UPDATE_BATHOPPHAP', 'FGA_HSBA_DV_INSERT_BATHOPPHAP', 'FGA_HSBA_DV_UPDATE_MAKTV_BATHOPPHAP', 'FGA_HSBA_DV_UPDATE_KETQUA_BATHOPPHAP', 'FGA_HSBA_DV_UPDATE_OTHER_BATHOPPHAP', 'FGA_HSBA_DV_DELETE_BATHOPPHAP')) AS TOTAL_AUDIT,
        (SELECT COUNT(*) FROM DBA_AUDIT_TRAIL WHERE OWNER = 'ADMINHOS' AND RETURNCODE != 0
         AND OBJ_NAME IN ('HSBA', 'DONTHUOC', 'HSBA_DV', 'VW_NHANVIEN_SELF', 'VW_BENHNHAN_SELF', 'SP_CAPNHAT_KETLUAN_HSBA', 'FN_DEM_DONTHUOC')) +
        (SELECT COUNT(*) FROM DBA_FGA_AUDIT_TRAIL WHERE OBJECT_SCHEMA = 'ADMINHOS' AND POLICY_NAME LIKE '%BATHOPPHAP%') AS ABNORMAL_ALERTS
    FROM DUAL;
END;
/

-- 3. Thống kê dashboard DPV
CREATE OR REPLACE PROCEDURE SP_GET_DASHBOARD_DPV (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        (SELECT COUNT(DISTINCT MAKTV) 
         FROM ADMINHOS.HSBA_DV 
         WHERE TRUNC(NGAYDV) = TRUNC(SYSDATE) AND MAKTV IS NOT NULL) AS ACTIVE_KTVS,
        (SELECT COUNT(*) 
         FROM ADMINHOS.HSBA_DV 
         WHERE MAKTV IS NULL) AS PENDING_KTV,
        (SELECT COUNT(*) 
         FROM ADMINHOS.HSBA_DV 
         WHERE KETQUA IS NOT NULL AND TRUNC(NGAYDV) = TRUNC(SYSDATE)) AS COMPLETED_SERVICES,
        (SELECT COUNT(*) 
         FROM ADMINHOS.VW_THONGBAO_APP
         WHERE TRUNC(NGAYGIO) = TRUNC(SYSDATE)) AS TODAY_NOTICES
    FROM DUAL;
END;
/

-- 4. Danh sách bệnh nhân cần phân công KTV
CREATE OR REPLACE PROCEDURE SP_GET_PATIENTS_NEED_ASSIGNMENT (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        DV.MAHSBA,
        BN.TENBN AS TEN_BENH_NHAN,
        COALESCE(
            NV.CHUYENKHOA,
            CASE HS.MAKHOA
                WHEN 'KTH' THEN N'Khoa tiêu hóa'
                WHEN 'KTK' THEN N'Khoa thần kinh'
                WHEN 'KTM' THEN N'Khoa tim mạch'
                ELSE N'Chưa xác định'
            END
        ) AS KHOA,
        DV.LOAIDV AS DICH_VU_CAN
    FROM ADMINHOS.HSBA_DV DV
    JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
    JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
    LEFT JOIN ADMINHOS.VW_NHANVIEN_DIEUPHOI NV ON HS.MABS = NV.MANV AND NV.VAITRO = N'Bác sĩ/Y sĩ'
    WHERE DV.MAKTV IS NULL;
END;
/

-- 5. Thống kê dashboard BS
CREATE OR REPLACE PROCEDURE SP_GET_DASHBOARD_BS (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT
        (SELECT COUNT(*) FROM ADMINHOS.HSBA WHERE MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')) AS MANAGED_HSBAS,
        (SELECT COUNT(DISTINCT DV.MAHSBA)
         FROM ADMINHOS.HSBA_DV DV
         JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
         WHERE HS.MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')
           AND DV.MAKTV IS NULL) AS PENDING_KTV,
        (SELECT COUNT(DISTINCT DV.MAHSBA)
         FROM ADMINHOS.HSBA_DV DV
         JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
         WHERE HS.MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')
           AND DV.MAKTV IS NOT NULL
           AND (DV.KETQUA IS NULL OR DV.KETQUA = N'Chưa có kết quả')) AS PENDING_RESULTS,
        (SELECT COUNT(*)
         FROM ADMINHOS.VW_THONGBAO_APP
         WHERE TRUNC(NGAYGIO) = TRUNC(SYSDATE)) AS TODAY_NOTICES
    FROM DUAL;
END;
/

-- 6. Danh sách HSBA lập trong tháng của bác sĩ
CREATE OR REPLACE PROCEDURE SP_GET_RECENT_HSBA_THIS_MONTH (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        HS.MAHSBA,
        BN.TENBN,
        BN.MABN,
        BN.PHAI,
        FLOOR(MONTHS_BETWEEN(SYSDATE, BN.NGAYSINH) / 12) AS TUOI,
        HS.NGAY,
        HS.CHANDOAN
    FROM ADMINHOS.HSBA HS
    JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
    WHERE HS.MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')
      AND TRUNC(HS.NGAY, 'MM') = TRUNC(SYSDATE, 'MM')
    ORDER BY HS.NGAY DESC, HS.MAHSBA DESC;
END;
/

-- 7. Danh sách đơn thuốc của bác sĩ quản lý
CREATE OR REPLACE PROCEDURE SP_GET_PRESCRIPTIONS_FOR_DOCTOR (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT
        DT.MAHSBA,
        DT.NGAYDT,
        HS.MABN,
        BN.TENBN,
        BN.PHAI,
        FLOOR(MONTHS_BETWEEN(SYSDATE, BN.NGAYSINH) / 12) AS TUOI,
        DT.TENTHUOC,
        DT.LIEUDUNG
    FROM ADMINHOS.DONTHUOC DT
    JOIN ADMINHOS.HSBA HS ON DT.MAHSBA = HS.MAHSBA
    JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
    ORDER BY DT.NGAYDT DESC, DT.MAHSBA ASC;
END;
/

-- 8. Thêm thuốc mới
CREATE OR REPLACE PROCEDURE SP_INSERT_DRUG (
    p_mahsba IN VARCHAR2,
    p_ngaydt IN DATE,
    p_tenthuoc IN NVARCHAR2,
    p_lieudung IN NVARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    INSERT INTO ADMINHOS.DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG)
    VALUES (p_mahsba, p_ngaydt, p_tenthuoc, p_lieudung);
    COMMIT;
END;
/

-- 9. Cập nhật thuốc
CREATE OR REPLACE PROCEDURE SP_UPDATE_DRUG (
    p_mahsba IN VARCHAR2,
    p_ngaydt IN DATE,
    p_old_tenthuoc IN NVARCHAR2,
    p_new_tenthuoc IN NVARCHAR2,
    p_new_lieudung IN NVARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    UPDATE ADMINHOS.DONTHUOC
    SET TENTHUOC = p_new_tenthuoc,
        LIEUDUNG = p_new_lieudung
    WHERE MAHSBA = p_mahsba
      AND NGAYDT = p_ngaydt
      AND TENTHUOC = p_old_tenthuoc;
    COMMIT;
END;
/

-- 10. Xóa thuốc
CREATE OR REPLACE PROCEDURE SP_DELETE_DRUG (
    p_mahsba IN VARCHAR2,
    p_ngaydt IN DATE,
    p_tenthuoc IN NVARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    DELETE FROM ADMINHOS.DONTHUOC
    WHERE MAHSBA = p_mahsba
      AND NGAYDT = p_ngaydt
      AND TENTHUOC = p_tenthuoc;
    COMMIT;
END;
/

-- 11. Lấy thông tin cá nhân nhân viên
CREATE OR REPLACE PROCEDURE SP_GET_PROFILE (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA, COSO 
    FROM ADMINHOS.VW_NHANVIEN_SELF;
END;
/

-- 12. Lấy thống kê hồ sơ của nhân viên
CREATE OR REPLACE PROCEDURE SP_GET_PROFILE_STATS (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        (SELECT COUNT(*) FROM ADMINHOS.HSBA) AS SO_HSBA,
        (
            SELECT COUNT(*) 
            FROM ADMINHOS.HSBA_DV DV
            JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
        ) AS SO_PHAN_CONG,
        (SELECT COUNT(DISTINCT MABN) FROM ADMINHOS.HSBA) AS SO_BENH_NHAN
    FROM DUAL;
END;
/

-- 13. Cập nhật hồ sơ nhân viên
-- Chính sách bảo mật được thực thi tại tầng CSDL (TC#5):
--   - Chỉ cập nhật được hồ sơ của chính mình (kiểm tra SESSION_USER)
--   - Chỉ 2 trường được phép sửa: QUEQUAN, SODT
--   - Các trường còn lại (HOTEN, PHAI, NGAYSINH, CMND, VAITRO, CHUYENKHOA, COSO)
--     được so sánh với giá trị DB thực tế; nếu khác -> RAISE_APPLICATION_ERROR cụ thể
CREATE OR REPLACE PROCEDURE SP_UPDATE_PROFILE (
    p_sodt       IN VARCHAR2,
    p_quequan    IN NVARCHAR2,
    p_manv       IN VARCHAR2,
    p_hoten      IN NVARCHAR2,
    p_phai       IN NVARCHAR2,
    p_ngaysinh   IN DATE,
    p_cmnd       IN VARCHAR2,
    p_vaitro     IN NVARCHAR2,
    p_chuyenkhoa IN NVARCHAR2,
    p_coso       IN NVARCHAR2
)
AUTHID DEFINER
AS
    v_session    VARCHAR2(128) := SYS_CONTEXT('USERENV','SESSION_USER');
    v_hoten      NVARCHAR2(200);
    v_phai       NVARCHAR2(10);
    v_ngaysinh   DATE;
    v_cmnd       VARCHAR2(30);
    v_vaitro     NVARCHAR2(50);
    v_chuyenkhoa NVARCHAR2(200);
    v_coso       NVARCHAR2(200);
    v_count      NUMBER;
BEGIN
    -- Buoc 1: Kiem tra quyen -- chi duoc cap nhat chinh ho so minh
    IF UPPER(NVL(p_manv,' ')) != UPPER(v_session) THEN
        RAISE_APPLICATION_ERROR(-20010,
            'Chinh sach bao mat: Khong duoc phep thay doi ma nhan vien');
    END IF;

    -- Buoc 2: Xac nhan ban ghi ton tai
    SELECT COUNT(*) INTO v_count FROM ADMINHOS.NHANVIEN WHERE MANV = v_session;
    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-20007, 'Ho so nhan vien khong ton tai');
    END IF;

    -- Buoc 3: Doc gia tri hien tai tu bang goc de so sanh (tranh loi encoding round-trip)
    SELECT HOTEN, PHAI, NGAYSINH, CMND, VAITRO, CHUYENKHOA, COSO
    INTO   v_hoten, v_phai, v_ngaysinh, v_cmnd, v_vaitro, v_chuyenkhoa, v_coso
    FROM   ADMINHOS.NHANVIEN
    WHERE  MANV = v_session;

    -- Buoc 4: Kiem tra tung truong bi han che -- phat hien co gang thay doi
    IF NVL(p_hoten,      N'__NULL__') != NVL(v_hoten,      N'__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20011,
            'Chinh sach bao mat: Khong duoc phep cap nhat Ho ten nhan vien');
    END IF;
    IF NVL(p_phai,       N'__NULL__') != NVL(v_phai,       N'__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20012,
            'Chinh sach bao mat: Khong duoc phep cap nhat Gioi tinh');
    END IF;
    -- Dung TRUNC de bo qua time component trong DATE
    IF TRUNC(NVL(p_ngaysinh, DATE '1900-01-01')) != TRUNC(NVL(v_ngaysinh, DATE '1900-01-01')) THEN
        RAISE_APPLICATION_ERROR(-20013,
            'Chinh sach bao mat: Khong duoc phep cap nhat Ngay sinh');
    END IF;
    IF NVL(p_cmnd,    '__NULL__') != NVL(v_cmnd,    '__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20014,
            'Chinh sach bao mat: Khong duoc phep cap nhat CMND/CCCD');
    END IF;
    IF NVL(p_vaitro,     N'__NULL__') != NVL(v_vaitro,     N'__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20015,
            'Chinh sach bao mat: Khong duoc phep cap nhat Vai tro');
    END IF;
    IF NVL(p_chuyenkhoa, N'__NULL__') != NVL(v_chuyenkhoa, N'__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20016,
            'Chinh sach bao mat: Khong duoc phep cap nhat Chuyen khoa');
    END IF;
    IF NVL(p_coso,       N'__NULL__') != NVL(v_coso,       N'__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20017,
            'Chinh sach bao mat: Khong duoc phep cap nhat Co so lam viec');
    END IF;

    -- Buoc 5: Chi cap nhat 2 truong duoc phep: QUEQUAN, SODT
    UPDATE ADMINHOS.NHANVIEN
    SET    QUEQUAN = p_quequan,
           SODT    = p_sodt
    WHERE  MANV = v_session;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20007, 'Khong tim thay ban ghi de cap nhat');
    END IF;

    COMMIT;
END;
/

-- 13.5. Doi mat khau cua chinh minh
CREATE OR REPLACE PROCEDURE SP_CHANGE_MY_PASSWORD (
    p_new_password IN VARCHAR2
) AUTHID DEFINER AS
    v_username VARCHAR2(128);
    v_sql VARCHAR2(500);
BEGIN
    v_username := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_sql := 'ALTER USER ' || v_username || ' IDENTIFIED BY "' || p_new_password || '"';
    EXECUTE IMMEDIATE v_sql;
END;
/

-- 14. Lấy toàn bộ bệnh nhân
CREATE OR REPLACE PROCEDURE SP_GET_ALL_PATIENTS (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT MABN, TENBN, PHAI, NGAYSINH, CCCD, SONHA, TENDUONG, QUANHUYEN, TINHTP, TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC 
    FROM ADMINHOS.BENHNHAN
    ORDER BY MABN;
END;
/

-- 15. Tìm kiếm bệnh nhân
CREATE OR REPLACE PROCEDURE SP_SEARCH_PATIENT (
    p_query IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT MABN, TENBN, PHAI, NGAYSINH, CCCD, SONHA, TENDUONG, QUANHUYEN, TINHTP, TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC 
    FROM ADMINHOS.BENHNHAN
    WHERE LOWER(MABN) = LOWER(p_query)
       OR LOWER(TENBN) = LOWER(p_query)
       OR CCCD = p_query;
END;
/

-- 16. Lấy mã bệnh nhân kế tiếp
CREATE OR REPLACE FUNCTION FN_GET_NEXT_PATIENT_ID
RETURN VARCHAR2
AS
    v_next_num NUMBER;
BEGIN
    SELECT NVL(MAX(TO_NUMBER(SUBSTR(MABN, 3))), 0) + 1
    INTO v_next_num
    FROM BENHNHAN
    WHERE MABN LIKE 'BN%';
    RETURN 'BN' || TO_CHAR(v_next_num, 'FM000000');
END;
/

-- 17. Thêm bệnh nhân mới
CREATE OR REPLACE PROCEDURE SP_INSERT_PATIENT (
    p_mabn IN VARCHAR2,
    p_tenbn IN NVARCHAR2,
    p_phai IN NVARCHAR2,
    p_ngaysinh IN DATE,
    p_cccd IN VARCHAR2,
    p_sonha IN NVARCHAR2,
    p_tenduong IN NVARCHAR2,
    p_quanhuyen IN NVARCHAR2,
    p_tinhtp IN NVARCHAR2,
    p_tiensubenh IN NVARCHAR2,
    p_tiensubenhgd IN NVARCHAR2,
    p_diungthuoc IN NVARCHAR2
)
AUTHID DEFINER
AS
    v_count NUMBER;
    v_sql   VARCHAR2(1000);
BEGIN
    INSERT INTO ADMINHOS.BENHNHAN (
        MABN, TENBN, PHAI, NGAYSINH, CCCD, 
        SONHA, TENDUONG, QUANHUYEN, TINHTP, 
        TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC
    ) VALUES (
        p_mabn, p_tenbn, p_phai, p_ngaysinh, p_cccd, 
        p_sonha, p_tenduong, p_quanhuyen, p_tinhtp, 
        p_tiensubenh, p_tiensubenhgd, p_diungthuoc
    );

    -- Tự động tạo user Oracle cho bệnh nhân mới để đăng nhập
    SELECT COUNT(*)
    INTO v_count
    FROM DBA_USERS
    WHERE USERNAME = UPPER(TRIM(p_mabn));

    IF v_count = 0 THEN
        v_sql := 'CREATE USER ' || UPPER(TRIM(p_mabn)) || ' IDENTIFIED BY "123" ACCOUNT UNLOCK';
        EXECUTE IMMEDIATE v_sql;
        v_sql := 'GRANT CREATE SESSION TO ' || UPPER(TRIM(p_mabn));
        EXECUTE IMMEDIATE v_sql;
        v_sql := 'GRANT ROLE_BENHNHAN TO ' || UPPER(TRIM(p_mabn));
        EXECUTE IMMEDIATE v_sql;
    END IF;

    COMMIT;
END;
/

-- 18. Cập nhật bệnh nhân
CREATE OR REPLACE PROCEDURE SP_UPDATE_PATIENT (
    p_mabn IN VARCHAR2,
    p_tenbn IN NVARCHAR2,
    p_phai IN NVARCHAR2,
    p_ngaysinh IN DATE,
    p_cccd IN VARCHAR2,
    p_sonha IN NVARCHAR2,
    p_tenduong IN NVARCHAR2,
    p_quanhuyen IN NVARCHAR2,
    p_tinhtp IN NVARCHAR2,
    p_tiensubenh IN NVARCHAR2,
    p_tiensubenhgd IN NVARCHAR2,
    p_diungthuoc IN NVARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    UPDATE ADMINHOS.BENHNHAN 
    SET TENBN = p_tenbn, 
        PHAI = p_phai, 
        NGAYSINH = p_ngaysinh, 
        CCCD = p_cccd, 
        SONHA = p_sonha, 
        TENDUONG = p_tenduong, 
        QUANHUYEN = p_quanhuyen, 
        TINHTP = p_tinhtp, 
        TIENSUBENH = p_tiensubenh, 
        TIENSUBENHGD = p_tiensubenhgd, 
        DIUNGTHUOC = p_diungthuoc
    WHERE MABN = p_mabn;
    COMMIT;
END;
/

-- 19. Lấy danh sách bệnh nhân cho bác sĩ
CREATE OR REPLACE PROCEDURE SP_GET_PATIENTS_FOR_DOCTOR (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT
        BN.MABN,
        BN.TENBN,
        BN.PHAI,
        BN.NGAYSINH,
        FLOOR(MONTHS_BETWEEN(SYSDATE, BN.NGAYSINH) / 12) AS TUOI,
        BN.CCCD,
        BN.SONHA,
        BN.TENDUONG,
        BN.QUANHUYEN,
        BN.TINHTP,
        BN.TIENSUBENH,
        BN.TIENSUBENHGD,
        BN.DIUNGTHUOC,
        (
            SELECT COUNT(*)
            FROM ADMINHOS.HSBA HS
            WHERE HS.MABN = BN.MABN
        ) AS SO_HSBA,
        (
            SELECT COUNT(*)
            FROM ADMINHOS.DONTHUOC DT
            JOIN ADMINHOS.HSBA HS ON DT.MAHSBA = HS.MAHSBA
            WHERE HS.MABN = BN.MABN
        ) AS SO_DONTHUOC
    FROM ADMINHOS.BENHNHAN BN
    ORDER BY BN.MABN;
END;
/

-- 20. Cập nhật tiền sử bệnh nhân
CREATE OR REPLACE PROCEDURE SP_UPDATE_PATIENT_HISTORY (
    p_mabn IN VARCHAR2,
    p_allergy IN NVARCHAR2,
    p_medical_history IN NVARCHAR2,
    p_family_history IN NVARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    UPDATE ADMINHOS.BENHNHAN
    SET DIUNGTHUOC = p_allergy,
        TIENSUBENH = p_medical_history,
        TIENSUBENHGD = p_family_history
    WHERE MABN = p_mabn;
    COMMIT;
END;
/

-- 21. Thêm HSBA mới
CREATE OR REPLACE PROCEDURE SP_INSERT_HSBA (
    p_mahsba IN VARCHAR2,
    p_mabn IN VARCHAR2,
    p_ngay IN DATE,
    p_chandoan IN NVARCHAR2,
    p_dieutri IN NVARCHAR2,
    p_mabs IN VARCHAR2,
    p_makhoa IN VARCHAR2,
    p_ketluan IN NVARCHAR2
)
AUTHID DEFINER
AS
    v_coso NVARCHAR2(100);
BEGIN
    -- Lấy cơ sở của DPV (hoặc người thực hiện)
    BEGIN
        SELECT COSO INTO v_coso
        FROM ADMINHOS.NHANVIEN
        WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER');
    EXCEPTION
        WHEN OTHERS THEN
            v_coso := NULL;
    END;

    INSERT INTO ADMINHOS.HSBA (
        MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN, COSO
    ) VALUES (
        p_mahsba, p_mabn, p_ngay, p_chandoan, p_dieutri, p_mabs, p_makhoa, p_ketluan, v_coso
    );
    COMMIT;
END;
/

-- 22. Lấy danh sách bác sĩ cho giao diện tạo HSBA
CREATE OR REPLACE PROCEDURE SP_GET_DOCTORS_FOR_TAOHSBA (
    p_specialty IN NVARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT MANV, HOTEN, CHUYENKHOA
    FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI
    WHERE VAITRO = N'Bác sĩ/Y sĩ'
      AND CHUYENKHOA = p_specialty
    ORDER BY MANV ASC;
END;
/

-- 23. Lấy danh sách chuyên khoa
CREATE OR REPLACE PROCEDURE SP_GET_DEPARTMENTS (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT DISTINCT CHUYENKHOA 
    FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI 
    WHERE CHUYENKHOA IS NOT NULL 
      AND VAITRO = N'Bác sĩ/Y sĩ'
    ORDER BY CHUYENKHOA ASC;
END;
/

-- 24. Lấy danh sách HSBA cho điều phối
CREATE OR REPLACE PROCEDURE SP_GET_HSBA_FOR_DIEUPHOI (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        HS.MAHSBA,
        HS.MABN,
        BN.TENBN AS TEN_BENH_NHAN,
        HS.NGAY,
        HS.CHANDOAN,
        HS.DIEUTRI,
        HS.MABS,
        HS.MAKHOA,
        BS.HOTEN AS TEN_BACSI,
        BS.CHUYENKHOA AS CHUYENKHOA_BACSI,
        HS.KETLUAN,
        CASE WHEN HS.COSO IS NULL OR HS.COSO = (
            SELECT DP.COSO 
            FROM ADMINHOS.NHANVIEN DP 
            WHERE DP.MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')
        ) THEN 1 ELSE 0 END AS CUNG_CO_SO
    FROM ADMINHOS.HSBA HS
    LEFT JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
    LEFT JOIN ADMINHOS.VW_NHANVIEN_DIEUPHOI BS ON HS.MABS = BS.MANV AND TRIM(BS.VAITRO) = N'Bác sĩ/Y sĩ'
    ORDER BY HS.MAHSBA;
END;
/

-- 25. Điều phối bác sĩ khoa phòng cho HSBA
CREATE OR REPLACE PROCEDURE SP_UPDATE_HSBA_DEPT_DOC (
    p_mahsba IN VARCHAR2,
    p_makhoa IN VARCHAR2,
    p_mabs IN VARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    UPDATE ADMINHOS.HSBA
    SET MAKHOA = p_makhoa,
        MABS = p_mabs
    WHERE MAHSBA = p_mahsba;
    COMMIT;
END;
/

-- 26. Lấy danh sách HSBA cho bác sĩ
CREATE OR REPLACE PROCEDURE SP_GET_HSBA_FOR_DOCTOR (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        HS.MAHSBA,
        HS.MABN,
        BN.TENBN AS TEN_BENH_NHAN,
        BN.PHAI AS GIOI_TINH,
        BN.NGAYSINH,
        BN.CCCD,
        BN.SONHA,
        BN.TENDUONG,
        BN.QUANHUYEN,
        BN.TINHTP,
        BN.DIUNGTHUOC,
        BN.TIENSUBENH,
        HS.NGAY,
        HS.CHANDOAN,
        HS.DIEUTRI,
        HS.MAKHOA,
        HS.KETLUAN
    FROM ADMINHOS.HSBA HS
    LEFT JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
    ORDER BY HS.NGAY DESC;
END;
/

-- 27. Lấy danh sách dịch vụ của HSBA
CREATE OR REPLACE PROCEDURE SP_GET_SERVICES_FOR_HSBA (
    p_mahsba IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT LOAIDV, NGAYDV, MAKTV, KETQUA
    FROM ADMINHOS.HSBA_DV
    WHERE MAHSBA = p_mahsba
    ORDER BY NGAYDV ASC;
END;
/

-- 28. Xóa dịch vụ kỹ thuật chưa thực hiện khỏi HSBA
CREATE OR REPLACE PROCEDURE SP_DELETE_HSBA_SERVICE (
    p_mahsba IN VARCHAR2,
    p_loaidv IN NVARCHAR2,
    p_ngaydv IN DATE
)
AUTHID DEFINER
AS
BEGIN
    DELETE FROM ADMINHOS.HSBA_DV
    WHERE MAHSBA = p_mahsba
      AND LOAIDV = p_loaidv
      AND NGAYDV = p_ngaydv
      AND MAKTV IS NULL;
    COMMIT;
END;
/

-- 29. Lấy danh sách đơn thuốc của HSBA
CREATE OR REPLACE PROCEDURE SP_GET_PRESCRIPTIONS_FOR_HSBA (
    p_mahsba IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT TENTHUOC, LIEUDUNG
    FROM ADMINHOS.DONTHUOC
    WHERE MAHSBA = p_mahsba
    ORDER BY NGAYDT ASC;
END;
/

-- 30. Cập nhật chi tiết chẩn đoán và điều trị của HSBA
CREATE OR REPLACE PROCEDURE SP_UPDATE_HSBA_DETAILS (
    p_mahsba IN VARCHAR2,
    p_chandoan IN NVARCHAR2,
    p_dieutri IN NVARCHAR2,
    p_ketluan IN NVARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    UPDATE ADMINHOS.HSBA
    SET CHANDOAN = p_chandoan,
        DIEUTRI  = p_dieutri,
        KETLUAN  = p_ketluan
    WHERE MAHSBA = p_mahsba;
    COMMIT;
END;
/

-- 31. Chỉ định dịch vụ kỹ thuật cho HSBA
CREATE OR REPLACE PROCEDURE SP_INSERT_HSBA_SERVICE (
    p_mahsba IN VARCHAR2,
    p_loaidv IN NVARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    INSERT INTO ADMINHOS.HSBA_DV (
        MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA
    ) VALUES (
        p_mahsba, p_loaidv, SYSDATE, NULL, N'Chưa có kết quả'
    );
    COMMIT;
END;
/

-- 32. Kê đơn thuốc mới cho HSBA
CREATE OR REPLACE PROCEDURE SP_INSERT_DONTHUOC (
    p_mahsba IN VARCHAR2,
    p_tenthuoc IN NVARCHAR2,
    p_lieudung IN NVARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    INSERT INTO ADMINHOS.DONTHUOC (
        MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
    ) VALUES (
        p_mahsba, SYSDATE, p_tenthuoc, p_lieudung
    );
    COMMIT;
END;
/

-- 33. Lấy danh sách HSBA của bệnh nhân
CREATE OR REPLACE PROCEDURE SP_GET_HSBA_FOR_PATIENT (
    p_mabn IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        HS.MAHSBA,
        HS.MABN,
        BN.TENBN AS TEN_BENH_NHAN,
        BN.PHAI AS GIOI_TINH,
        BN.NGAYSINH,
        BN.CCCD,
        BN.SONHA,
        BN.TENDUONG,
        BN.QUANHUYEN,
        BN.TINHTP,
        BN.DIUNGTHUOC,
        BN.TIENSUBENH,
        HS.NGAY,
        HS.NGAY AS NGAYTAO,
        HS.CHANDOAN,
        HS.DIEUTRI,
        HS.MAKHOA,
        HS.KETLUAN,
        HS.MABS,
        NV.HOTEN AS TENBS,
        NV.CHUYENKHOA AS TENKHOA
    FROM ADMINHOS.HSBA HS
    LEFT JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
    LEFT JOIN ADMINHOS.NHANVIEN NV ON HS.MABS = NV.MANV
    WHERE HS.MABN = UPPER(p_mabn)
    ORDER BY HS.NGAY DESC;
END;
/

-- 34. Lấy chi tiết HSBA theo mã
CREATE OR REPLACE PROCEDURE SP_GET_HSBA_DETAILS_BY_ID (
    p_mahsba IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        HS.MAHSBA,
        HS.MABN,
        BN.TENBN AS TEN_BENH_NHAN,
        BN.PHAI AS GIOI_TINH,
        BN.NGAYSINH,
        BN.CCCD,
        BN.SONHA,
        BN.TENDUONG,
        BN.QUANHUYEN,
        BN.TINHTP,
        BN.DIUNGTHUOC,
        BN.TIENSUBENH,
        HS.NGAY,
        HS.NGAY AS NGAYTAO,
        HS.CHANDOAN,
        HS.DIEUTRI,
        HS.MAKHOA,
        HS.KETLUAN,
        HS.MABS,
        NV.HOTEN AS TENBS,
        NV.CHUYENKHOA AS TENKHOA
    FROM ADMINHOS.HSBA HS
    LEFT JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
    LEFT JOIN ADMINHOS.NHANVIEN NV ON HS.MABS = NV.MANV
    WHERE HS.MAHSBA = p_mahsba;
END;
/

-- 35. Lay danh sach yeu cau dich vu cho phan cong
CREATE OR REPLACE PROCEDURE SP_GET_ALL_SERVICE_REQUESTS (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        DV.MAHSBA,
        BN.MABN AS MA_BENH_NHAN,
        BN.TENBN AS TEN_BENH_NHAN,
        DV.LOAIDV AS DICH_VU_CAN,
        DV.NGAYDV AS NGAY_DICH_VU,
        DV.KETQUA AS KET_QUA,
        DV.MAKTV AS MA_KTV,
        CASE 
            WHEN DV.MAKTV IS NULL THEN N'Chưa phân công'
            ELSE NV.HOTEN
            END AS KTV_PHU_TRACH,
        CASE 
            WHEN DV.MAKTV IS NULL THEN N'Chờ phân công'
            WHEN DV.KETQUA = N'Chưa có kết quả' THEN N'Đã phân công'
            ELSE N'Hoàn thành'
        END AS TRANG_THAI
    FROM ADMINHOS.HSBA_DV DV
    JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
    JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
    LEFT JOIN ADMINHOS.VW_NHANVIEN_DIEUPHOI NV 
        ON DV.MAKTV = NV.MANV 
        AND NV.VAITRO = N'Kỹ thuật viên'
    ORDER BY DV.NGAYDV DESC, DV.MAHSBA DESC;
END;
/

-- 36. Lay danh sach ky thuat vien
CREATE OR REPLACE PROCEDURE SP_GET_ALL_TECHNICIANS (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT 
        NV.MANV,
        NV.HOTEN,
        NV.CHUYENKHOA
    FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI NV
    WHERE NV.VAITRO = N'Kỹ thuật viên'
    ORDER BY NV.MANV ASC;
END;
/

-- 37. Phan cong ky thuat vien cho dich vu
CREATE OR REPLACE PROCEDURE SP_ASSIGN_TECHNICIAN (
    p_mahsba IN VARCHAR2,
    p_loaidv IN NVARCHAR2,
    p_maktv IN VARCHAR2
)
AUTHID DEFINER
AS
BEGIN
    UPDATE ADMINHOS.HSBA_DV 
    SET MAKTV = p_maktv
    WHERE MAHSBA = p_mahsba AND LOAIDV = p_loaidv;
    COMMIT;
END;
/

-- 38. Lay danh sach thong bao
CREATE OR REPLACE PROCEDURE SP_GET_NOTIFICATIONS (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT MATB, NOIDUNG, NGAYGIO, DIADIEM, NHAN_OLS 
    FROM ADMINHOS.VW_THONGBAO_APP 
    ORDER BY NGAYGIO DESC;
END;
/

-- Cấp quyền thực thi cho các role và user
GRANT EXECUTE ON SP_XEM_AUDIT_LOG TO admin_ph2;
GRANT EXECUTE ON SP_XEM_AUDIT_LOG TO DBA;

GRANT EXECUTE ON SP_GET_DASHBOARD_QTV TO admin_ph2;
GRANT EXECUTE ON SP_GET_DASHBOARD_QTV TO DBA;

DECLARE
    -- Mảng chứa các SP/FN của Điều phối viên
    TYPE t_name_list IS TABLE OF VARCHAR2(100);
    v_dpv_procs t_name_list := t_name_list(
        'SP_GET_DASHBOARD_DPV',
        'SP_GET_PATIENTS_NEED_ASSIGNMENT',
        'SP_GET_ALL_PATIENTS',
        'SP_SEARCH_PATIENT',
        'FN_GET_NEXT_PATIENT_ID',
        'SP_INSERT_PATIENT',
        'SP_UPDATE_PATIENT',
        'SP_INSERT_HSBA',
        'SP_GET_DOCTORS_FOR_TAOHSBA',
        'SP_GET_DEPARTMENTS',
        'SP_GET_HSBA_FOR_DIEUPHOI',
        'SP_UPDATE_HSBA_DEPT_DOC',
        'SP_GET_ALL_SERVICE_REQUESTS',
        'SP_GET_ALL_TECHNICIANS',
        'SP_ASSIGN_TECHNICIAN'
    );
    
    -- Mảng chứa các SP/FN của Bác sĩ/Y sĩ
    v_bs_procs t_name_list := t_name_list(
        'SP_GET_DASHBOARD_BS',
        'SP_GET_RECENT_HSBA_THIS_MONTH',
        'SP_GET_PRESCRIPTIONS_FOR_DOCTOR',
        'SP_INSERT_DRUG',
        'SP_UPDATE_DRUG',
        'SP_DELETE_DRUG',
        'SP_UPDATE_PATIENT_HISTORY',
        'SP_GET_PATIENTS_FOR_DOCTOR',
        'SP_GET_HSBA_FOR_DOCTOR',
        'SP_GET_SERVICES_FOR_HSBA',
        'SP_DELETE_HSBA_SERVICE',
        'SP_GET_PRESCRIPTIONS_FOR_HSBA',
        'SP_UPDATE_HSBA_DETAILS',
        'SP_INSERT_HSBA_SERVICE',
        'SP_INSERT_DONTHUOC',
        'SP_GET_HSBA_FOR_PATIENT',
        'SP_GET_HSBA_DETAILS_BY_ID',
        'FN_DEM_DONTHUOC',
        'SP_CAPNHAT_KETLUAN_HSBA'
    );
    
    -- Mảng chứa các SP/FN dùng chung cho cả hai vai trò
    v_common_procs t_name_list := t_name_list(
        'SP_GET_PROFILE',
        'SP_GET_PROFILE_STATS',
        'SP_UPDATE_PROFILE',
        'SP_GET_NOTIFICATIONS',
        'SP_CHANGE_MY_PASSWORD'
    );
BEGIN
    -- 1. Cấp quyền cho Điều phối viên (DPV)
    FOR u IN (
        SELECT MANV FROM ADMINHOS.NHANVIEN WHERE VAITRO = N'Điều phối viên'
    ) LOOP
        -- Cấp SP riêng của DPV
        FOR i IN 1..v_dpv_procs.COUNT LOOP
            EXECUTE IMMEDIATE 'GRANT EXECUTE ON ADMINHOS.' || v_dpv_procs(i) || ' TO ' || u.MANV;
        END LOOP;
        
        -- Cấp SP dùng chung
        FOR i IN 1..v_common_procs.COUNT LOOP
            EXECUTE IMMEDIATE 'GRANT EXECUTE ON ADMINHOS.' || v_common_procs(i) || ' TO ' || u.MANV;
        END LOOP;
    END LOOP;

    -- 2. Cấp quyền cho Bác sĩ/Y sĩ (BS)
    FOR u IN (
        SELECT MANV FROM ADMINHOS.NHANVIEN WHERE VAITRO = N'Bác sĩ/Y sĩ'
    ) LOOP
        -- Cấp SP riêng của BS
        FOR i IN 1..v_bs_procs.COUNT LOOP
            EXECUTE IMMEDIATE 'GRANT EXECUTE ON ADMINHOS.' || v_bs_procs(i) || ' TO ' || u.MANV;
        END LOOP;
        
        -- Cấp SP dùng chung
        FOR i IN 1..v_common_procs.COUNT LOOP
            EXECUTE IMMEDIATE 'GRANT EXECUTE ON ADMINHOS.' || v_common_procs(i) || ' TO ' || u.MANV;
        END LOOP;
    END LOOP;

    -- 3. Cấp quyền cho Kỹ thuật viên (KTV)
    FOR u IN (
        SELECT MANV FROM ADMINHOS.NHANVIEN WHERE VAITRO = N'Kỹ thuật viên'
    ) LOOP
        -- Cấp SP dùng chung
        FOR i IN 1..v_common_procs.COUNT LOOP
            EXECUTE IMMEDIATE 'GRANT EXECUTE ON ADMINHOS.' || v_common_procs(i) || ' TO ' || u.MANV;
        END LOOP;
    END LOOP;
END;
/

-- 39. SP_GET_SERVICES_FOR_KTV: Lay danh sach dich vu cua KTV (VPD tu loc theo user dang nhap)
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_GET_SERVICES_FOR_KTV(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT
            v.MAHSBA,
            v.LOAIDV,
            v.NGAYDV,
            v.KETQUA,
            b.MABN,
            b.TENBN,
            b.PHAI,
            b.NGAYSINH,
            b.CCCD,
            b.SONHA,
            b.TENDUONG,
            b.QUANHUYEN,
            b.TINHTP
        FROM ADMINHOS.VW_HSBA_DV_KTV v
        LEFT JOIN ADMINHOS.HSBA h ON v.MAHSBA = h.MAHSBA
        LEFT JOIN ADMINHOS.BENHNHAN b ON h.MABN = b.MABN
        ORDER BY v.NGAYDV DESC;
END;
/

-- 40. SP_UPDATE_SERVICE_RESULT: Cap nhat ket qua dich vu cua KTV
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_UPDATE_SERVICE_RESULT(
    p_mahsba IN VARCHAR2,
    p_loaidv IN NVARCHAR2,
    p_ngaydv IN VARCHAR2,
    p_ketqua IN NVARCHAR2
) AS
BEGIN
    UPDATE ADMINHOS.VW_HSBA_DV_KTV
    SET KETQUA = p_ketqua
    WHERE MAHSBA = p_mahsba
      AND LOAIDV = p_loaidv
      AND TRUNC(NGAYDV) = TO_DATE(REPLACE(p_ngaydv, '-', '/'), 'DD/MM/YYYY');
    COMMIT;
END;
/

-- Cap quyen cho ROLE_KYTHUATVIEN (dung pattern cua script goc)
GRANT EXECUTE ON ADMINHOS.SP_GET_SERVICES_FOR_KTV  TO ROLE_KYTHUATVIEN;
GRANT EXECUTE ON ADMINHOS.SP_UPDATE_SERVICE_RESULT TO ROLE_KYTHUATVIEN;

-- 41. SP_GET_PATIENT_SELF: Lay thong tin ca nhan benh nhan (VPD tu loc theo user dang nhap)
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_GET_PATIENT_SELF(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT *
        FROM ADMINHOS.VW_BENHNHAN_SELF;
END;
/

-- 42. SP_UPDATE_PATIENT_HISTORY_SELF: Cap nhat tien su benh cua benh nhan (VPD tu loc)
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_UPDATE_PATIENT_HISTORY_SELF(
    p_tiensubenh   IN NVARCHAR2,
    p_tiensubenhgd IN NVARCHAR2,
    p_diungthuoc   IN NVARCHAR2
) AS
BEGIN
    UPDATE ADMINHOS.VW_BENHNHAN_SELF
    SET TIENSUBENH   = p_tiensubenh,
        TIENSUBENHGD = p_tiensubenhgd,
        DIUNGTHUOC   = p_diungthuoc;
    COMMIT;
END;
/

-- 43. SP_UPDATE_PATIENT_ADDRESS_SELF: Cap nhat dia chi benh nhan (VPD tu loc)
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_UPDATE_PATIENT_ADDRESS_SELF(
    p_sonha     IN NVARCHAR2,
    p_tenduong  IN NVARCHAR2,
    p_quanhuyen IN NVARCHAR2,
    p_tinhtp    IN NVARCHAR2
) AS
BEGIN
    UPDATE ADMINHOS.VW_BENHNHAN_SELF
    SET SONHA     = p_sonha,
        TENDUONG  = p_tenduong,
        QUANHUYEN = p_quanhuyen,
        TINHTP    = p_tinhtp;
    COMMIT;
END;
/

-- 44b. SP_UPDATE_PATIENT_SELF: Cap nhat ho so benh nhan (TC#5 - bao mat tai tang CSDL)
-- Chi cap nhat duoc chinh ho so minh (SESSION_USER); chi sua duoc dia chi + tien su.
-- Cac truong bi han che (MABN, TENBN, PHAI, NGAYSINH, CCCD) duoc kiem tra trong SP;
-- neu co thay doi -> RAISE_APPLICATION_ERROR cu the cho tung truong.
CREATE OR REPLACE PROCEDURE SP_UPDATE_PATIENT_SELF (
    p_mabn         IN VARCHAR2,
    p_tenbn        IN NVARCHAR2,
    p_phai         IN NVARCHAR2,
    p_ngaysinh     IN DATE,
    p_cccd         IN VARCHAR2,
    p_sonha        IN NVARCHAR2,
    p_tenduong     IN NVARCHAR2,
    p_quanhuyen    IN NVARCHAR2,
    p_tinhtp       IN NVARCHAR2,
    p_tiensubenh   IN NVARCHAR2,
    p_tiensubenhgd IN NVARCHAR2,
    p_diungthuoc   IN NVARCHAR2
)
AUTHID DEFINER
AS
    v_session  VARCHAR2(128) := SYS_CONTEXT('USERENV','SESSION_USER');
    v_tenbn    NVARCHAR2(200);
    v_phai     NVARCHAR2(10);
    v_ngaysinh DATE;
    v_cccd     VARCHAR2(30);
    v_count    NUMBER;
BEGIN
    -- Buoc 1: Chi duoc cap nhat chinh ho so minh
    IF UPPER(NVL(p_mabn,' ')) != UPPER(v_session) THEN
        RAISE_APPLICATION_ERROR(-20020,
            'Chinh sach bao mat: Khong duoc phep thay doi ma benh nhan');
    END IF;

    SELECT COUNT(*) INTO v_count FROM ADMINHOS.BENHNHAN WHERE MABN = v_session;
    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-20005, 'Ho so benh nhan khong ton tai');
    END IF;

    -- Buoc 2: Doc gia tri hien tai tu bang goc de so sanh
    SELECT TENBN, PHAI, NGAYSINH, CCCD
    INTO   v_tenbn, v_phai, v_ngaysinh, v_cccd
    FROM   ADMINHOS.BENHNHAN
    WHERE  MABN = v_session;

    -- Buoc 3: Kiem tra cac truong bi han che
    IF NVL(p_tenbn,    N'__NULL__') != NVL(v_tenbn,    N'__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20021,
            'Chinh sach bao mat: Khong duoc phep cap nhat Ten benh nhan');
    END IF;
    IF NVL(p_phai,     N'__NULL__') != NVL(v_phai,     N'__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20022,
            'Chinh sach bao mat: Khong duoc phep cap nhat Gioi tinh');
    END IF;
    IF TRUNC(NVL(p_ngaysinh, DATE '1900-01-01')) != TRUNC(NVL(v_ngaysinh, DATE '1900-01-01')) THEN
        RAISE_APPLICATION_ERROR(-20023,
            'Chinh sach bao mat: Khong duoc phep cap nhat Ngay sinh');
    END IF;
    IF NVL(p_cccd, '__NULL__') != NVL(v_cccd, '__NULL__') THEN
        RAISE_APPLICATION_ERROR(-20024,
            'Chinh sach bao mat: Khong duoc phep cap nhat CCCD');
    END IF;

    -- Buoc 4: Chi cap nhat cac truong duoc phep
    UPDATE ADMINHOS.BENHNHAN
    SET    SONHA        = p_sonha,
           TENDUONG     = p_tenduong,
           QUANHUYEN    = p_quanhuyen,
           TINHTP       = p_tinhtp,
           TIENSUBENH   = p_tiensubenh,
           TIENSUBENHGD = p_tiensubenhgd,
           DIUNGTHUOC   = p_diungthuoc
    WHERE  MABN = v_session;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20005, 'Khong tim thay ban ghi de cap nhat');
    END IF;

    COMMIT;
END;
/

-- Cap quyen cho ROLE_BENHNHAN (dung pattern cua script goc)
GRANT EXECUTE ON ADMINHOS.SP_GET_PATIENT_SELF            TO ROLE_BENHNHAN;
GRANT EXECUTE ON ADMINHOS.SP_UPDATE_PATIENT_HISTORY_SELF TO ROLE_BENHNHAN;
GRANT EXECUTE ON ADMINHOS.SP_UPDATE_PATIENT_ADDRESS_SELF TO ROLE_BENHNHAN;
GRANT EXECUTE ON ADMINHOS.SP_UPDATE_PATIENT_SELF         TO ROLE_BENHNHAN;
GRANT EXECUTE ON ADMINHOS.SP_GET_HSBA_FOR_PATIENT        TO ROLE_BENHNHAN;
GRANT EXECUTE ON ADMINHOS.SP_GET_HSBA_DETAILS_BY_ID      TO ROLE_BENHNHAN;
GRANT EXECUTE ON ADMINHOS.SP_GET_SERVICES_FOR_HSBA       TO ROLE_BENHNHAN;
GRANT EXECUTE ON ADMINHOS.SP_GET_PRESCRIPTIONS_FOR_HSBA  TO ROLE_BENHNHAN;
GRANT EXECUTE ON ADMINHOS.SP_GET_NOTIFICATIONS           TO ROLE_BENHNHAN;

-- 44. SP_GET_BACKUP_HISTORY: Lay lich su backup tu V$BACKUP_SET (can quyen DBA/SELECT_CATALOG_ROLE)
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_GET_BACKUP_HISTORY(
    p_cursor OUT SYS_REFCURSOR
) AUTHID CURRENT_USER AS
BEGIN
    OPEN p_cursor FOR
        'SELECT
            ''REC-'' || BS.RECID                                          AS ID,
            BS.COMPLETION_TIME                                            AS START_TIME,
            CASE WHEN BS.BACKUP_TYPE = ''D'' THEN ''FULL'' ELSE ''INCR'' END AS TYPE,
            ''SYSTEM''                                                     AS SOURCE,
            ROUND(BS.INPUT_BYTES / (1024 * 1024), 2) || '' MB''          AS SIZE,
            BS.ELAPSED_SECONDS || ''s''                                   AS DURATION,
            BP.STATUS
        FROM V$BACKUP_SET BS
        LEFT JOIN V$BACKUP_PIECE BP
               ON BS.SET_STAMP = BP.SET_STAMP
              AND BS.SET_COUNT = BP.SET_COUNT
        ORDER BY BS.COMPLETION_TIME DESC';
END;
/


-- Cap quyen cho admin_ph2 va DBA 
GRANT EXECUTE ON ADMINHOS.SP_GET_BACKUP_HISTORY TO admin_ph2;
GRANT EXECUTE ON ADMINHOS.SP_GET_BACKUP_HISTORY TO DBA;


-- ==========================================================
-- SAO LƯU & PHỤC HỒI - DATA PUMP EXPORT
-- Chạy với quyền ADMINHOS (đã có GRANT ANY ROLE, DBA)
-- ==========================================================
SET SERVEROUTPUT ON SIZE UNLIMITED
SET DEFINE OFF
WHENEVER SQLERROR CONTINUE

-- -------------------------------------------------------
-- BƯỚC 1: Xác định đường dẫn DATA_PUMP_DIR mặc định Oracle
--         và tạo HOSPITALX_BACKUP_DIR trỏ về cùng đường dẫn
--         (không cần tạo folder thủ công - dùng thư mục có sẵn)
-- -------------------------------------------------------
DECLARE
    v_dp_path   VARCHAR2(500);
    v_sql       VARCHAR2(1000);
BEGIN
    -- Lấy đường dẫn của DATA_PUMP_DIR (luôn có sẵn trong mỗi Oracle install)
    BEGIN
        SELECT DIRECTORY_PATH INTO v_dp_path
        FROM   DBA_DIRECTORIES
        WHERE  DIRECTORY_NAME = 'DATA_PUMP_DIR'
        AND    ROWNUM = 1;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            BEGIN
                SELECT DIRECTORY_PATH INTO v_dp_path
                FROM   DBA_DIRECTORIES
                WHERE  ROWNUM = 1;
            EXCEPTION
                WHEN NO_DATA_FOUND THEN
                    v_dp_path := 'C:\oracle\backup';
            END;
    END;

    DBMS_OUTPUT.PUT_LINE('>>> Data Pump directory path: ' || v_dp_path);

    -- Tạo HOSPITALX_BACKUP_DIR trỏ về cùng đường dẫn (dùng alias để dễ nhận biết)
    v_sql := 'CREATE OR REPLACE DIRECTORY HOSPITALX_BACKUP_DIR AS ''' || v_dp_path || '''';
    EXECUTE IMMEDIATE v_sql;
    DBMS_OUTPUT.PUT_LINE('>>> Đã tạo HOSPITALX_BACKUP_DIR -> ' || v_dp_path);
END;
/

-- -------------------------------------------------------
-- BƯỚC 2: Cấp quyền READ/WRITE trên directory cho các user
-- Cap bang SYS de tranh ORA-01749 (ADMINHOS khong duoc tu GRANT cho chinh minh).
-- -------------------------------------------------------
SET DEFINE ON
CONNECT SYS/"&SYS_PWD"@localhost:1521/PDBHOSX AS SYSDBA;
SET DEFINE OFF
GRANT READ, WRITE ON DIRECTORY HOSPITALX_BACKUP_DIR TO ADMINHOS;
GRANT READ, WRITE ON DIRECTORY HOSPITALX_BACKUP_DIR TO admin_ph2;
GRANT READ, WRITE ON DIRECTORY DATA_PUMP_DIR        TO ADMINHOS;
GRANT READ, WRITE ON DIRECTORY DATA_PUMP_DIR        TO admin_ph2;

-- -------------------------------------------------------
-- BƯỚC 3: Cấp quyền Data Pump cho admin_ph2 và ADMINHOS
--         (ADMINHOS có GRANT ANY ROLE nên làm được)
-- -------------------------------------------------------
GRANT DATAPUMP_EXP_FULL_DATABASE TO admin_ph2;
GRANT DATAPUMP_EXP_FULL_DATABASE TO ADMINHOS;
GRANT DATAPUMP_IMP_FULL_DATABASE TO admin_ph2;
GRANT DATAPUMP_IMP_FULL_DATABASE TO ADMINHOS;
GRANT SELECT_CATALOG_ROLE        TO admin_ph2;
GRANT SELECT_CATALOG_ROLE        TO ADMINHOS;

-- Quay lai ADMINHOS de tao cac doi tuong thuoc schema ADMINHOS (bang, SP...).
CONNECT adminHos/123@localhost:1521/PDBHOSX

-- -------------------------------------------------------
-- BƯỚC 4: Tạo/Reset bảng BACKUP_LOG và Sequence
-- -------------------------------------------------------
BEGIN
    EXECUTE IMMEDIATE 'DROP SEQUENCE ADMINHOS.SEQ_BACKUP_LOG';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE ADMINHOS.BACKUP_LOG CASCADE CONSTRAINTS PURGE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

CREATE TABLE ADMINHOS.BACKUP_LOG (
    ID           VARCHAR2(50)   PRIMARY KEY,
    START_TIME   TIMESTAMP      DEFAULT CURRENT_TIMESTAMP,
    END_TIME     TIMESTAMP,
    TYPE         VARCHAR2(10)   DEFAULT 'FULL',
    SOURCE       VARCHAR2(20)   DEFAULT 'MANUAL',
    DIR_NAME     VARCHAR2(100),
    FILE_NAME    VARCHAR2(200),
    FILE_PATH    VARCHAR2(500),
    FILE_SIZE_MB NUMBER(10,2),
    DURATION_SEC NUMBER(10),
    STATUS       VARCHAR2(20)   DEFAULT 'RUNNING',
    ERROR_MSG    VARCHAR2(1000),
    CREATED_BY   VARCHAR2(50)   DEFAULT SYS_CONTEXT('USERENV','SESSION_USER')
)
/

CREATE SEQUENCE ADMINHOS.SEQ_BACKUP_LOG
    START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE
/

-- -------------------------------------------------------
-- BƯỚC 5: SP_RUN_DATAPUMP_BACKUP
--         Tự động tìm directory, xử lý lỗi, ghi BACKUP_LOG
-- -------------------------------------------------------
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_RUN_DATAPUMP_BACKUP (
    p_backup_type  IN  VARCHAR2 DEFAULT 'FULL',
    p_tag          IN  VARCHAR2 DEFAULT NULL,
    p_log_id       OUT VARCHAR2,
    p_status       OUT VARCHAR2,
    p_message      OUT VARCHAR2
) AUTHID DEFINER
AS
    v_job_handle   NUMBER;
    v_job_state    VARCHAR2(30);
    v_log_id       VARCHAR2(50);
    v_filename     VARCHAR2(200);
    v_logfile      VARCHAR2(200);
    v_job_name     VARCHAR2(30);
    v_dir_name     VARCHAR2(100);
    v_start_time   TIMESTAMP;
    v_end_time     TIMESTAMP;
    v_seq          NUMBER;
    v_ts           VARCHAR2(20);
    v_err_msg      VARCHAR2(1000);
BEGIN
    v_ts       := TO_CHAR(SYSDATE, 'YYYYMMDD_HH24MISS');
    v_seq      := ADMINHOS.SEQ_BACKUP_LOG.NEXTVAL;
    v_log_id   := 'BK-' || TO_CHAR(SYSDATE, 'YYYYMMDD') || '-' || LPAD(TO_CHAR(v_seq), 4, '0');
    p_log_id   := v_log_id;

    -- Tên file không chứa ký tự đặc biệt
    v_filename := 'HX_BCK_' || v_ts || '.dmp';
    v_logfile  := 'HX_BCK_' || v_ts || '.log';
    -- Job name tối đa 30 ký tự, không dấu gạch ngang, không ký tự đặc biệt
    v_job_name := 'HXEXP' || TO_CHAR(SYSDATE, 'MMDDHH24MISS');

    -- Tìm directory theo thứ tự ưu tiên
    v_dir_name := NULL;
    BEGIN
        SELECT DIRECTORY_NAME INTO v_dir_name FROM DBA_DIRECTORIES
        WHERE  DIRECTORY_NAME = 'HOSPITALX_BACKUP_DIR' AND ROWNUM = 1;
    EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
    END;

    IF v_dir_name IS NULL THEN
        BEGIN
            SELECT DIRECTORY_NAME INTO v_dir_name FROM DBA_DIRECTORIES
            WHERE  DIRECTORY_NAME = 'DATA_PUMP_DIR' AND ROWNUM = 1;
        EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
        END;
    END IF;

    IF v_dir_name IS NULL THEN
        p_status  := 'FAILED';
        p_message := 'Khong tim thay Oracle Directory. Chay lai script setup.';
        p_log_id  := NULL;
        RETURN;
    END IF;

    -- Ghi bản ghi RUNNING vào log
    v_start_time := SYSTIMESTAMP;
    INSERT INTO ADMINHOS.BACKUP_LOG
        (ID, START_TIME, TYPE, SOURCE, DIR_NAME, FILE_NAME, STATUS, CREATED_BY)
    VALUES
        (v_log_id, v_start_time,
         UPPER(NVL(p_backup_type, 'FULL')), 'MANUAL',
         v_dir_name, v_filename, 'RUNNING',
         SYS_CONTEXT('USERENV', 'SESSION_USER'));
    COMMIT;

    -- Mở Data Pump Export Job
    v_job_handle := DBMS_DATAPUMP.OPEN(
        operation => 'EXPORT',
        job_mode  => 'SCHEMA',
        job_name  => v_job_name
    );

    -- File dump
    DBMS_DATAPUMP.ADD_FILE(
        handle    => v_job_handle,
        filename  => v_filename,
        directory => v_dir_name,
        filetype  => DBMS_DATAPUMP.KU$_FILE_TYPE_DUMP_FILE
    );

    -- File log
    DBMS_DATAPUMP.ADD_FILE(
        handle    => v_job_handle,
        filename  => v_logfile,
        directory => v_dir_name,
        filetype  => DBMS_DATAPUMP.KU$_FILE_TYPE_LOG_FILE
    );

    -- Chỉ export schema ADMINHOS
    DBMS_DATAPUMP.METADATA_FILTER(
        handle => v_job_handle,
        name   => 'SCHEMA_EXPR',
        value  => q'[IN ('ADMINHOS')]'
    );

    -- Nén metadata (METADATA_ONLY không yêu cầu Advanced Compression license)
    DBMS_DATAPUMP.SET_PARAMETER(
        handle => v_job_handle,
        name   => 'COMPRESSION',
        value  => 'METADATA_ONLY'
    );

    -- Chạy và chờ kết quả
    DBMS_DATAPUMP.START_JOB(v_job_handle);
    DBMS_DATAPUMP.WAIT_FOR_JOB(v_job_handle, v_job_state);
    v_end_time := SYSTIMESTAMP;

    IF v_job_state = 'COMPLETED' THEN
        UPDATE ADMINHOS.BACKUP_LOG
        SET  STATUS       = 'SUCCESS',
             END_TIME     = v_end_time,
             DURATION_SEC = GREATEST(0, ROUND(
                 (CAST(v_end_time AS DATE) - CAST(v_start_time AS DATE)) * 86400
             )),
             FILE_PATH    = v_dir_name || ':' || v_filename
        WHERE ID = v_log_id;
        COMMIT;
        p_status  := 'SUCCESS';
        p_message := 'Sao lưu thành công! File: ' || v_filename
                  || ' | Thư mục Oracle: ' || v_dir_name;
    ELSE
        UPDATE ADMINHOS.BACKUP_LOG
        SET  STATUS    = 'FAILED',
             END_TIME  = v_end_time,
             ERROR_MSG = 'Job state: ' || v_job_state
        WHERE ID = v_log_id;
        COMMIT;
        p_status  := 'FAILED';
        p_message := 'Job kết thúc với trạng thái: ' || v_job_state;
    END IF;

    DBMS_DATAPUMP.DETACH(v_job_handle);

EXCEPTION
    WHEN OTHERS THEN
        v_err_msg := SUBSTR(SQLERRM, 1, 900);
        BEGIN
            UPDATE ADMINHOS.BACKUP_LOG
            SET  STATUS    = 'FAILED',
                 END_TIME  = SYSTIMESTAMP,
                 ERROR_MSG = v_err_msg
            WHERE ID = v_log_id;
            COMMIT;
        EXCEPTION WHEN OTHERS THEN NULL;
        END;
        BEGIN
            DBMS_DATAPUMP.STOP_JOB(v_job_handle, 1, 0);
        EXCEPTION WHEN OTHERS THEN NULL;
        END;
        p_status  := 'FAILED';
        p_message := v_err_msg;
        -- Khong RAISE de app nhan duoc p_status/p_message thay vi exception
END SP_RUN_DATAPUMP_BACKUP;
/

-- -------------------------------------------------------
-- BƯỚC 6: SP_GET_BACKUP_HISTORY_APP
-- -------------------------------------------------------
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_GET_BACKUP_HISTORY_APP (
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT
            ID,
            START_TIME,
            TYPE,
            SOURCE,
            CASE WHEN FILE_SIZE_MB IS NOT NULL
                 THEN TO_CHAR(FILE_SIZE_MB, 'FM9990.0') || ' MB'
                 ELSE NVL(FILE_NAME, '-')
            END AS "SIZE",
            CASE WHEN DURATION_SEC IS NOT NULL
                 THEN TO_CHAR(FLOOR(DURATION_SEC / 60)) || 'm '
                   || TO_CHAR(MOD(DURATION_SEC, 60))   || 's'
                 ELSE '-'
            END AS DURATION,
            STATUS
        FROM  ADMINHOS.BACKUP_LOG
        ORDER BY START_TIME DESC;
END;
/

-- -------------------------------------------------------
-- BƯỚC 6B: PHỤC HỒI DỮ LIỆU TỪ BẢN BACKUP (DATA PUMP IMPORT)
-- Dùng cho nút "Phục hồi" trên app. Nạp lại DỮ LIỆU schema ADMINHOS từ
-- file .dmp đã chọn, GIỮ NGUYÊN cấu trúc + chính sách bảo mật
-- (VPD/OLS/trigger/view) bằng TABLE_EXISTS_ACTION = TRUNCATE.
-- Tạm vô hiệu khóa ngoại trong lúc nạp để tránh lỗi thứ tự truncate.
-- -------------------------------------------------------
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE ADMINHOS.SEQ_RESTORE_LOG'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE ADMINHOS.RESTORE_LOG CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

CREATE TABLE ADMINHOS.RESTORE_LOG (
    ID         VARCHAR2(50)  PRIMARY KEY,
    START_TIME TIMESTAMP     DEFAULT CURRENT_TIMESTAMP,
    END_TIME   TIMESTAMP,
    BACKUP_ID  VARCHAR2(50),
    DUMP_FILE  VARCHAR2(200),
    DIR_NAME   VARCHAR2(100),
    STATUS     VARCHAR2(20)  DEFAULT 'RUNNING',
    MESSAGE    VARCHAR2(1000),
    RUN_BY     VARCHAR2(50)  DEFAULT SYS_CONTEXT('USERENV','SESSION_USER')
)
/
CREATE SEQUENCE ADMINHOS.SEQ_RESTORE_LOG START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE
/

CREATE OR REPLACE PROCEDURE ADMINHOS.SP_RUN_DATAPUMP_RESTORE (
    p_backup_id IN  VARCHAR2,
    p_log_id    OUT VARCHAR2,
    p_status    OUT VARCHAR2,
    p_message   OUT VARCHAR2
) AUTHID DEFINER
AS
    v_job      NUMBER;
    v_state    VARCHAR2(30);
    v_file     VARCHAR2(200);
    v_dir      VARCHAR2(100);
    v_logfile  VARCHAR2(200);
    v_jobname  VARCHAR2(30);
    v_id       VARCHAR2(50);
    v_ts       VARCHAR2(20);
    v_err      VARCHAR2(1000);

    PROCEDURE set_fk(p_enable IN BOOLEAN) IS
    BEGIN
        FOR c IN (
            SELECT table_name, constraint_name
            FROM   USER_CONSTRAINTS
            WHERE  constraint_type = 'R'
              AND  table_name IN ('HSBA','HSBA_DV','DONTHUOC','BENHNHAN','NHANVIEN')
        ) LOOP
            BEGIN
                IF p_enable THEN
                    EXECUTE IMMEDIATE 'ALTER TABLE '||c.table_name
                        ||' ENABLE NOVALIDATE CONSTRAINT '||c.constraint_name;
                ELSE
                    EXECUTE IMMEDIATE 'ALTER TABLE '||c.table_name
                        ||' DISABLE CONSTRAINT '||c.constraint_name;
                END IF;
            EXCEPTION WHEN OTHERS THEN NULL;
            END;
        END LOOP;
    END set_fk;
BEGIN
    -- 1. Lấy thông tin bản backup từ BACKUP_LOG
    BEGIN
        SELECT FILE_NAME, DIR_NAME
        INTO   v_file, v_dir
        FROM   ADMINHOS.BACKUP_LOG
        WHERE  ID = p_backup_id AND STATUS = 'SUCCESS' AND ROWNUM = 1;
    EXCEPTION WHEN NO_DATA_FOUND THEN
        p_status  := 'FAILED';
        p_message := 'Khong tim thay ban sao luu THANH CONG co ma: ' || NVL(p_backup_id, '(null)');
        p_log_id  := NULL;
        RETURN;
    END;

    v_ts      := TO_CHAR(SYSDATE, 'YYYYMMDD_HH24MISS');
    v_id      := 'RS-' || TO_CHAR(SYSDATE, 'YYYYMMDD') || '-'
                 || LPAD(TO_CHAR(ADMINHOS.SEQ_RESTORE_LOG.NEXTVAL), 4, '0');
    p_log_id  := v_id;
    v_logfile := 'HX_RESTORE_' || v_ts || '.log';
    v_jobname := 'HXIMP' || TO_CHAR(SYSDATE, 'MMDDHH24MISS');

    INSERT INTO ADMINHOS.RESTORE_LOG (ID, START_TIME, BACKUP_ID, DUMP_FILE, DIR_NAME, STATUS)
    VALUES (v_id, SYSTIMESTAMP, p_backup_id, v_file, v_dir, 'RUNNING');
    COMMIT;

    -- 2. Tạm vô hiệu khóa ngoại để TRUNCATE không vướng thứ tự cha/con
    set_fk(FALSE);

    -- 3. Data Pump IMPORT (chỉ nạp lại DỮ LIỆU, giữ cấu trúc + bảo mật)
    v_job := DBMS_DATAPUMP.OPEN(
        operation => 'IMPORT',
        job_mode  => 'SCHEMA',
        job_name  => v_jobname,
        version   => 'LATEST'
    );
    DBMS_DATAPUMP.ADD_FILE(v_job, v_file,    v_dir, DBMS_DATAPUMP.KU$_FILE_TYPE_DUMP_FILE);
    DBMS_DATAPUMP.ADD_FILE(v_job, v_logfile, v_dir, DBMS_DATAPUMP.KU$_FILE_TYPE_LOG_FILE);
    DBMS_DATAPUMP.METADATA_FILTER(v_job, 'SCHEMA_EXPR', q'[IN ('ADMINHOS')]');
    DBMS_DATAPUMP.SET_PARAMETER(v_job, 'TABLE_EXISTS_ACTION', 'TRUNCATE');
    DBMS_DATAPUMP.START_JOB(v_job);
    DBMS_DATAPUMP.WAIT_FOR_JOB(v_job, v_state);

    -- 4. Bật lại khóa ngoại
    set_fk(TRUE);

    IF v_state = 'COMPLETED' THEN
        p_status  := 'SUCCESS';
        p_message := 'Phuc hoi du lieu thanh cong tu file ' || v_file;
    ELSE
        p_status  := 'COMPLETED_WITH_WARN';
        p_message := 'Import ket thuc voi trang thai: ' || v_state
                  || '. Xem chi tiet trong ' || v_logfile;
    END IF;

    UPDATE ADMINHOS.RESTORE_LOG
       SET STATUS = p_status, END_TIME = SYSTIMESTAMP, MESSAGE = p_message
     WHERE ID = v_id;
    COMMIT;

    BEGIN DBMS_DATAPUMP.DETACH(v_job); EXCEPTION WHEN OTHERS THEN NULL; END;

EXCEPTION
    WHEN OTHERS THEN
        v_err := SUBSTR(SQLERRM, 1, 900);
        BEGIN set_fk(TRUE); EXCEPTION WHEN OTHERS THEN NULL; END;   -- luôn bật lại FK
        p_status  := 'FAILED';
        p_message := v_err;
        BEGIN
            UPDATE ADMINHOS.RESTORE_LOG
               SET STATUS = 'FAILED', END_TIME = SYSTIMESTAMP, MESSAGE = v_err
             WHERE ID = v_id;
            COMMIT;
        EXCEPTION WHEN OTHERS THEN NULL;
        END;
        BEGIN DBMS_DATAPUMP.STOP_JOB(v_job, 1, 0); EXCEPTION WHEN OTHERS THEN NULL; END;
END SP_RUN_DATAPUMP_RESTORE;
/
SHOW ERRORS PROCEDURE ADMINHOS.SP_RUN_DATAPUMP_RESTORE;

CREATE OR REPLACE PROCEDURE ADMINHOS.SP_GET_RESTORE_HISTORY (
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT ID, START_TIME, BACKUP_ID, DUMP_FILE, STATUS, MESSAGE, RUN_BY
        FROM   ADMINHOS.RESTORE_LOG
        ORDER BY START_TIME DESC;
END;
/

-- -------------------------------------------------------
-- BƯỚC 7: Cấp đầy đủ quyền
-- -------------------------------------------------------
GRANT EXECUTE ON ADMINHOS.SP_RUN_DATAPUMP_RESTORE   TO admin_ph2;
GRANT EXECUTE ON ADMINHOS.SP_RUN_DATAPUMP_RESTORE   TO DBA;
GRANT EXECUTE ON ADMINHOS.SP_GET_RESTORE_HISTORY    TO admin_ph2;
GRANT EXECUTE ON ADMINHOS.SP_GET_RESTORE_HISTORY    TO DBA;
GRANT SELECT  ON ADMINHOS.RESTORE_LOG               TO admin_ph2;
GRANT SELECT  ON ADMINHOS.RESTORE_LOG               TO DBA;
GRANT EXECUTE ON ADMINHOS.SP_RUN_DATAPUMP_BACKUP    TO admin_ph2;
GRANT EXECUTE ON ADMINHOS.SP_RUN_DATAPUMP_BACKUP    TO DBA;
GRANT EXECUTE ON ADMINHOS.SP_GET_BACKUP_HISTORY_APP TO admin_ph2;
GRANT EXECUTE ON ADMINHOS.SP_GET_BACKUP_HISTORY_APP TO DBA;
GRANT SELECT, INSERT, UPDATE ON ADMINHOS.BACKUP_LOG TO admin_ph2;
GRANT SELECT ON ADMINHOS.BACKUP_LOG                 TO DBA;


-- =======================================================================
-- =======================================================================
-- YÊU CẦU 4 (tt): KHÔI PHỤC DỮ LIỆU DỰA VÀO NHẬT KÝ KIỂM TOÁN (FGA)
--                 SAU KHI CÓ SỰ CỐ (TỰ ĐỘNG)
-- -----------------------------------------------------------------------
-- Ý tưởng:
--   YC3 (FGA) đã ghi lại MỌI hành vi bất hợp pháp trên HSBA / HSBA_DV
--   (và mọi lần sửa DONTHUOC) kèm EXTENDED_TIMESTAMP chính xác.
--   Ta dùng chính mốc thời gian đó để Flashback dữ liệu về trạng thái
--   NGAY TRƯỚC sự cố:
--     (1) Đọc DBA_FGA_AUDIT_TRAIL -> lấy thời điểm sự cố sớm nhất.
--     (2) Lùi 1 giây  -> thời điểm dữ liệu còn nguyên vẹn.
--     (3) TIMESTAMP_TO_SCN -> đổi sang SCN sạch.
--     (4) SELECT ... AS OF SCN (Flashback Query) -> lấy bản gốc.
--     (5) MERGE / INSERT / DELETE -> đưa bảng hiện tại khớp bản gốc:
--           - hoàn tác UPDATE  (cập nhật lại cột về giá trị cũ)
--           - hoàn tác DELETE  (chèn lại dòng bị xóa trộm)
--           - hoàn tác INSERT  (xóa dòng bị chèn trộm)
--
-- Ghi chú kỹ thuật:
--   - Tất cả SP chạy bằng quyền ADMINHOS (AUTHID DEFINER). ADMINHOS là
--     chủ sở hữu bảng nên KHÔNG bị VPD lọc -> thấy & sửa được toàn bộ dòng.
--   - Điều kiện hoạt động: dữ liệu sự cố còn nằm trong UNDO
--     (UNDO_RETENTION đủ dài) -> nên chạy khôi phục sớm sau sự cố.
--   - Bỏ qua các hành vi do chính ADMINHOS / ADMIN_PH2 thực hiện để
--     không tự coi thao tác khôi phục là "sự cố".
-- =======================================================================
-- =======================================================================

-- -----------------------------------------------------------------------
-- BƯỚC R1: Bảng & sequence ghi nhật ký KHÔI PHỤC
-- -----------------------------------------------------------------------
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE ADMINHOS.SEQ_RECOVERY_LOG'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE ADMINHOS.RECOVERY_LOG CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

CREATE TABLE ADMINHOS.RECOVERY_LOG (
    ID            VARCHAR2(50)  PRIMARY KEY,
    RUN_TIME      TIMESTAMP     DEFAULT CURRENT_TIMESTAMP,
    SCN_HSBA      NUMBER,
    SCN_HSBA_DV   NUMBER,
    SCN_DONTHUOC  NUMBER,
    ROWS_AFFECTED NUMBER        DEFAULT 0,
    STATUS        VARCHAR2(20)  DEFAULT 'RUNNING',
    DETAILS       VARCHAR2(1000),
    RUN_BY        VARCHAR2(50)  DEFAULT SYS_CONTEXT('USERENV','SESSION_USER')
)
/

CREATE SEQUENCE ADMINHOS.SEQ_RECOVERY_LOG START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE
/

-- -----------------------------------------------------------------------
-- BƯỚC R2: Hàm lấy "SCN sạch" của một bảng từ nhật ký kiểm toán FGA
--   p_object    : tên bảng (HSBA / HSBA_DV / DONTHUOC)
--   p_policy_like: mẫu tên policy FGA xác định "sự cố" cần khôi phục
--   Trả về: SCN của thời điểm (sự cố sớm nhất - 1 giây), hoặc NULL nếu
--           không có sự cố / không đổi được sang SCN (ngoài cửa sổ UNDO).
-- -----------------------------------------------------------------------
CREATE OR REPLACE FUNCTION ADMINHOS.FN_GET_CLEAN_SCN (
    p_object      IN VARCHAR2,
    p_policy_like IN VARCHAR2 DEFAULT '%BATHOPPHAP%'
) RETURN NUMBER
AUTHID DEFINER
AS
    v_ts  TIMESTAMP;
    v_scn NUMBER;
BEGIN
    SELECT MIN(EXTENDED_TIMESTAMP)
    INTO   v_ts
    FROM   DBA_FGA_AUDIT_TRAIL
    WHERE  OBJECT_SCHEMA = 'ADMINHOS'
      AND  OBJECT_NAME   = p_object
      AND  POLICY_NAME   LIKE p_policy_like
      AND  DB_USER NOT IN ('ADMINHOS', 'ADMIN_PH2');   -- bỏ qua thao tác của admin

    IF v_ts IS NULL THEN
        RETURN NULL;                                   -- không có sự cố
    END IF;

    v_scn := TIMESTAMP_TO_SCN(v_ts - INTERVAL '1' SECOND);
    RETURN v_scn;
EXCEPTION
    WHEN OTHERS THEN
        RETURN NULL;                                   -- ngoài cửa sổ flashback...
END FN_GET_CLEAN_SCN;
/
SHOW ERRORS FUNCTION ADMINHOS.FN_GET_CLEAN_SCN;

-- -----------------------------------------------------------------------
-- BƯỚC R3: Khôi phục bảng HSBA về SCN sạch
--   Hoàn tác UPDATE (CHANDOAN/DIEUTRI/KETLUAN/MABS/MAKHOA/MABN/NGAY),
--   hoàn tác DELETE (chèn lại) và INSERT (xóa đi) bất hợp pháp.
-- -----------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_KHOIPHUC_HSBA_THEO_AUDIT (
    p_scn        IN  NUMBER,
    p_updated    OUT NUMBER,
    p_reinserted OUT NUMBER,
    p_removed    OUT NUMBER
) AUTHID DEFINER
AS
BEGIN
    p_updated := 0; p_reinserted := 0; p_removed := 0;
    IF p_scn IS NULL THEN RETURN; END IF;

    -- (1) Hoàn tác UPDATE: chỉ cập nhật những dòng thực sự khác bản gốc
    MERGE INTO ADMINHOS.HSBA cur
    USING (SELECT * FROM ADMINHOS.HSBA AS OF SCN p_scn) snap
    ON (cur.MAHSBA = snap.MAHSBA)
    WHEN MATCHED THEN UPDATE SET
        cur.MABN     = snap.MABN,
        cur.NGAY     = snap.NGAY,
        cur.CHANDOAN = snap.CHANDOAN,
        cur.DIEUTRI  = snap.DIEUTRI,
        cur.MABS     = snap.MABS,
        cur.MAKHOA   = snap.MAKHOA,
        cur.KETLUAN  = snap.KETLUAN
    WHERE  NVL(cur.CHANDOAN,'#') <> NVL(snap.CHANDOAN,'#')
        OR NVL(cur.DIEUTRI ,'#') <> NVL(snap.DIEUTRI ,'#')
        OR NVL(cur.KETLUAN ,'#') <> NVL(snap.KETLUAN ,'#')
        OR NVL(cur.MABS    ,'#') <> NVL(snap.MABS    ,'#')
        OR NVL(cur.MAKHOA  ,'#') <> NVL(snap.MAKHOA  ,'#')
        OR NVL(cur.MABN    ,'#') <> NVL(snap.MABN    ,'#');
    p_updated := SQL%ROWCOUNT;

    -- (2) Hoàn tác DELETE: dòng có trong bản gốc nhưng đã biến mất -> chèn lại
    INSERT INTO ADMINHOS.HSBA (MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN)
    SELECT s.MAHSBA, s.MABN, s.NGAY, s.CHANDOAN, s.DIEUTRI, s.MABS, s.MAKHOA, s.KETLUAN
    FROM   ADMINHOS.HSBA AS OF SCN p_scn s
    WHERE  NOT EXISTS (SELECT 1 FROM ADMINHOS.HSBA c WHERE c.MAHSBA = s.MAHSBA);
    p_reinserted := SQL%ROWCOUNT;

    -- (3) Hoàn tác INSERT: dòng hiện có nhưng không có trong bản gốc -> xóa
    DELETE FROM ADMINHOS.HSBA c
    WHERE  NOT EXISTS (SELECT 1 FROM ADMINHOS.HSBA AS OF SCN p_scn s WHERE s.MAHSBA = c.MAHSBA);
    p_removed := SQL%ROWCOUNT;
END SP_KHOIPHUC_HSBA_THEO_AUDIT;
/
SHOW ERRORS PROCEDURE ADMINHOS.SP_KHOIPHUC_HSBA_THEO_AUDIT;

-- -----------------------------------------------------------------------
-- BƯỚC R4: Khôi phục bảng HSBA_DV về SCN sạch (PK ghép: MAHSBA+LOAIDV+NGAYDV)
--   Lưu ý: trigger TRG_DELETE_HSBA_DV_MAKTV chặn DELETE khi MAKTV<>NULL,
--   nên TẠM VÔ HIỆU trigger ở SP tổng (BƯỚC R6) trước khi gọi SP này.
-- -----------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_KHOIPHUC_HSBA_DV_THEO_AUDIT (
    p_scn        IN  NUMBER,
    p_updated    OUT NUMBER,
    p_reinserted OUT NUMBER,
    p_removed    OUT NUMBER
) AUTHID DEFINER
AS
BEGIN
    p_updated := 0; p_reinserted := 0; p_removed := 0;
    IF p_scn IS NULL THEN RETURN; END IF;

    -- (1) Hoàn tác UPDATE (MAKTV / KETQUA)
    MERGE INTO ADMINHOS.HSBA_DV cur
    USING (SELECT * FROM ADMINHOS.HSBA_DV AS OF SCN p_scn) snap
    ON (    cur.MAHSBA = snap.MAHSBA
        AND cur.LOAIDV = snap.LOAIDV
        AND cur.NGAYDV = snap.NGAYDV)
    WHEN MATCHED THEN UPDATE SET
        cur.MAKTV  = snap.MAKTV,
        cur.KETQUA = snap.KETQUA
    WHERE  NVL(cur.MAKTV ,'#') <> NVL(snap.MAKTV ,'#')
        OR NVL(cur.KETQUA,'#') <> NVL(snap.KETQUA,'#');
    p_updated := SQL%ROWCOUNT;

    -- (2) Hoàn tác DELETE -> chèn lại
    INSERT INTO ADMINHOS.HSBA_DV (MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA)
    SELECT s.MAHSBA, s.LOAIDV, s.NGAYDV, s.MAKTV, s.KETQUA
    FROM   ADMINHOS.HSBA_DV AS OF SCN p_scn s
    WHERE  NOT EXISTS (
        SELECT 1 FROM ADMINHOS.HSBA_DV c
        WHERE c.MAHSBA = s.MAHSBA AND c.LOAIDV = s.LOAIDV AND c.NGAYDV = s.NGAYDV);
    p_reinserted := SQL%ROWCOUNT;

    -- (3) Hoàn tác INSERT -> xóa dòng chèn trộm
    DELETE FROM ADMINHOS.HSBA_DV c
    WHERE  NOT EXISTS (
        SELECT 1 FROM ADMINHOS.HSBA_DV AS OF SCN p_scn s
        WHERE s.MAHSBA = c.MAHSBA AND s.LOAIDV = c.LOAIDV AND s.NGAYDV = c.NGAYDV);
    p_removed := SQL%ROWCOUNT;
END SP_KHOIPHUC_HSBA_DV_THEO_AUDIT;
/
SHOW ERRORS PROCEDURE ADMINHOS.SP_KHOIPHUC_HSBA_DV_THEO_AUDIT;

-- -----------------------------------------------------------------------
-- BƯỚC R5: Khôi phục bảng DONTHUOC về SCN sạch (PK ghép: MAHSBA+NGAYDT+TENTHUOC)
-- -----------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_KHOIPHUC_DONTHUOC_THEO_AUDIT (
    p_scn        IN  NUMBER,
    p_updated    OUT NUMBER,
    p_reinserted OUT NUMBER,
    p_removed    OUT NUMBER
) AUTHID DEFINER
AS
BEGIN
    p_updated := 0; p_reinserted := 0; p_removed := 0;
    IF p_scn IS NULL THEN RETURN; END IF;

    -- (1) Hoàn tác UPDATE (LIEUDUNG là cột duy nhất ngoài khóa)
    MERGE INTO ADMINHOS.DONTHUOC cur
    USING (SELECT * FROM ADMINHOS.DONTHUOC AS OF SCN p_scn) snap
    ON (    cur.MAHSBA   = snap.MAHSBA
        AND cur.NGAYDT   = snap.NGAYDT
        AND cur.TENTHUOC = snap.TENTHUOC)
    WHEN MATCHED THEN UPDATE SET
        cur.LIEUDUNG = snap.LIEUDUNG
    WHERE  NVL(cur.LIEUDUNG,'#') <> NVL(snap.LIEUDUNG,'#');
    p_updated := SQL%ROWCOUNT;

    -- (2) Hoàn tác DELETE
    INSERT INTO ADMINHOS.DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG)
    SELECT s.MAHSBA, s.NGAYDT, s.TENTHUOC, s.LIEUDUNG
    FROM   ADMINHOS.DONTHUOC AS OF SCN p_scn s
    WHERE  NOT EXISTS (
        SELECT 1 FROM ADMINHOS.DONTHUOC c
        WHERE c.MAHSBA = s.MAHSBA AND c.NGAYDT = s.NGAYDT AND c.TENTHUOC = s.TENTHUOC);
    p_reinserted := SQL%ROWCOUNT;

    -- (3) Hoàn tác INSERT
    DELETE FROM ADMINHOS.DONTHUOC c
    WHERE  NOT EXISTS (
        SELECT 1 FROM ADMINHOS.DONTHUOC AS OF SCN p_scn s
        WHERE s.MAHSBA = c.MAHSBA AND s.NGAYDT = c.NGAYDT AND s.TENTHUOC = c.TENTHUOC);
    p_removed := SQL%ROWCOUNT;
END SP_KHOIPHUC_DONTHUOC_THEO_AUDIT;
/
SHOW ERRORS PROCEDURE ADMINHOS.SP_KHOIPHUC_DONTHUOC_THEO_AUDIT;

-- -----------------------------------------------------------------------
-- BƯỚC R6: SP TỔNG - KHÔI PHỤC TỰ ĐỘNG TOÀN BỘ DỰA VÀO NHẬT KÝ KIỂM TOÁN
--   - Tự dò sự cố trên HSBA, HSBA_DV, DONTHUOC từ FGA.
--   - Khôi phục theo thứ tự an toàn khóa ngoại: HSBA -> HSBA_DV -> DONTHUOC.
--   - Tạm vô hiệu trigger chặn xóa HSBA_DV trong lúc khôi phục.
--   - Ghi RECOVERY_LOG, trả p_status / p_message cho ứng dụng.
-- -----------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_KHOIPHUC_TUDONG_THEO_AUDIT (
    p_log_id  OUT VARCHAR2,
    p_status  OUT VARCHAR2,
    p_message OUT VARCHAR2
) AUTHID DEFINER
AS
    v_scn_hsba NUMBER;
    v_scn_dv   NUMBER;
    v_scn_dt   NUMBER;
    u1 NUMBER := 0; r1 NUMBER := 0; d1 NUMBER := 0;
    u2 NUMBER := 0; r2 NUMBER := 0; d2 NUMBER := 0;
    u3 NUMBER := 0; r3 NUMBER := 0; d3 NUMBER := 0;
    v_total NUMBER := 0;
    v_id    VARCHAR2(50);
    v_msg   VARCHAR2(1000);
BEGIN
    v_id := 'RC-' || TO_CHAR(SYSDATE,'YYYYMMDD') || '-' ||
            LPAD(TO_CHAR(ADMINHOS.SEQ_RECOVERY_LOG.NEXTVAL), 4, '0');
    p_log_id := v_id;

    -- Dò "SCN sạch" cho từng bảng từ nhật ký kiểm toán
    v_scn_hsba := ADMINHOS.FN_GET_CLEAN_SCN('HSBA',     'FGA_HSBA_UPDATE_BATHOPPHAP');
    v_scn_dv   := ADMINHOS.FN_GET_CLEAN_SCN('HSBA_DV',  '%BATHOPPHAP%');
    v_scn_dt   := ADMINHOS.FN_GET_CLEAN_SCN('DONTHUOC', 'FGA_DONTHUOC_UPDATE');

    IF v_scn_hsba IS NULL AND v_scn_dv IS NULL AND v_scn_dt IS NULL THEN
        p_status  := 'NO_INCIDENT';
        p_message := 'Khong phat hien su co trong nhat ky kiem toan FGA. Khong can khoi phuc.';
        INSERT INTO ADMINHOS.RECOVERY_LOG (ID, RUN_TIME, ROWS_AFFECTED, STATUS, DETAILS)
        VALUES (v_id, SYSTIMESTAMP, 0, p_status, p_message);
        COMMIT;
        RETURN;
    END IF;

    -- Tạm vô hiệu trigger chặn xóa dịch vụ (để hoàn tác INSERT/DELETE trên HSBA_DV)
    BEGIN EXECUTE IMMEDIATE 'ALTER TRIGGER ADMINHOS.TRG_DELETE_HSBA_DV_MAKTV DISABLE';
    EXCEPTION WHEN OTHERS THEN NULL; END;

    -- Khôi phục theo thứ tự an toàn khóa ngoại
    ADMINHOS.SP_KHOIPHUC_HSBA_THEO_AUDIT    (v_scn_hsba, u1, r1, d1);
    ADMINHOS.SP_KHOIPHUC_HSBA_DV_THEO_AUDIT (v_scn_dv,   u2, r2, d2);
    ADMINHOS.SP_KHOIPHUC_DONTHUOC_THEO_AUDIT(v_scn_dt,   u3, r3, d3);

    -- Bật lại trigger
    BEGIN EXECUTE IMMEDIATE 'ALTER TRIGGER ADMINHOS.TRG_DELETE_HSBA_DV_MAKTV ENABLE';
    EXCEPTION WHEN OTHERS THEN NULL; END;

    v_total := u1+r1+d1 + u2+r2+d2 + u3+r3+d3;
    COMMIT;

    v_msg := 'HSBA[sua '   || u1 || ', chen lai ' || r1 || ', xoa ' || d1 || '] '
          || 'HSBA_DV[sua '|| u2 || ', chen lai ' || r2 || ', xoa ' || d2 || '] '
          || 'DONTHUOC[sua '|| u3 || ', chen lai ' || r3 || ', xoa ' || d3 || ']';
    p_status  := CASE WHEN v_total > 0 THEN 'RECOVERED' ELSE 'NOTHING_TO_DO' END;
    p_message := 'Khoi phuc theo nhat ky kiem toan hoan tat. Tong ' || v_total
              || ' dong da xu ly. Chi tiet: ' || v_msg;

    UPDATE ADMINHOS.RECOVERY_LOG
       SET ROWS_AFFECTED = v_total, STATUS = p_status, DETAILS = v_msg,
           SCN_HSBA = v_scn_hsba, SCN_HSBA_DV = v_scn_dv, SCN_DONTHUOC = v_scn_dt
     WHERE ID = v_id;
    IF SQL%ROWCOUNT = 0 THEN
        INSERT INTO ADMINHOS.RECOVERY_LOG
            (ID, RUN_TIME, SCN_HSBA, SCN_HSBA_DV, SCN_DONTHUOC, ROWS_AFFECTED, STATUS, DETAILS)
        VALUES (v_id, SYSTIMESTAMP, v_scn_hsba, v_scn_dv, v_scn_dt, v_total, p_status, v_msg);
    END IF;
    COMMIT;

EXCEPTION
    WHEN OTHERS THEN
        BEGIN EXECUTE IMMEDIATE 'ALTER TRIGGER ADMINHOS.TRG_DELETE_HSBA_DV_MAKTV ENABLE';
        EXCEPTION WHEN OTHERS THEN NULL; END;
        p_status  := 'FAILED';
        p_message := SUBSTR(SQLERRM, 1, 900);
        BEGIN
            INSERT INTO ADMINHOS.RECOVERY_LOG (ID, RUN_TIME, STATUS, DETAILS)
            VALUES (v_id, SYSTIMESTAMP, 'FAILED', p_message);
            COMMIT;
        EXCEPTION WHEN OTHERS THEN NULL; END;
END SP_KHOIPHUC_TUDONG_THEO_AUDIT;
/
SHOW ERRORS PROCEDURE ADMINHOS.SP_KHOIPHUC_TUDONG_THEO_AUDIT;

-- -----------------------------------------------------------------------
-- BƯỚC R7: SP xem DANH SÁCH SỰ CỐ phát hiện từ nhật ký kiểm toán (cho app)
-- -----------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_GET_SUCO_FROM_AUDIT (
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT
            CAST(DB_USER             AS VARCHAR2(50))   AS KE_TINH_NGHI,
            CAST(OBJECT_NAME         AS VARCHAR2(30))   AS BANG_BI_TAN_CONG,
            CAST(STATEMENT_TYPE      AS VARCHAR2(20))   AS HANH_VI,
            CAST(POLICY_NAME         AS VARCHAR2(60))   AS POLICY_FGA,
            EXTENDED_TIMESTAMP                          AS THOI_DIEM,
            CAST(SUBSTR(SQL_TEXT,1,400) AS VARCHAR2(400)) AS CAU_LENH
        FROM   DBA_FGA_AUDIT_TRAIL
        WHERE  OBJECT_SCHEMA = 'ADMINHOS'
          AND  (POLICY_NAME LIKE '%BATHOPPHAP%' OR POLICY_NAME = 'FGA_DONTHUOC_UPDATE')
          AND  DB_USER NOT IN ('ADMINHOS', 'ADMIN_PH2')
        ORDER BY EXTENDED_TIMESTAMP DESC;
END SP_GET_SUCO_FROM_AUDIT;
/

-- -----------------------------------------------------------------------
-- BƯỚC R8: SP xem LỊCH SỬ KHÔI PHỤC (cho app)
-- -----------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE ADMINHOS.SP_GET_RECOVERY_HISTORY (
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT ID, RUN_TIME, ROWS_AFFECTED, STATUS, DETAILS, RUN_BY
        FROM   ADMINHOS.RECOVERY_LOG
        ORDER BY RUN_TIME DESC;
END SP_GET_RECOVERY_HISTORY;
/

-- -----------------------------------------------------------------------
-- BƯỚC R9: Cấp quyền
-- -----------------------------------------------------------------------
GRANT EXECUTE ON ADMINHOS.SP_KHOIPHUC_TUDONG_THEO_AUDIT TO admin_ph2;
GRANT EXECUTE ON ADMINHOS.SP_KHOIPHUC_TUDONG_THEO_AUDIT TO DBA;
GRANT EXECUTE ON ADMINHOS.SP_GET_SUCO_FROM_AUDIT        TO admin_ph2;
GRANT EXECUTE ON ADMINHOS.SP_GET_SUCO_FROM_AUDIT        TO DBA;
GRANT EXECUTE ON ADMINHOS.SP_GET_RECOVERY_HISTORY       TO admin_ph2;
GRANT EXECUTE ON ADMINHOS.SP_GET_RECOVERY_HISTORY       TO DBA;
GRANT SELECT  ON ADMINHOS.RECOVERY_LOG                  TO admin_ph2;
GRANT SELECT  ON ADMINHOS.RECOVERY_LOG                  TO DBA;

-- =======================================================================
-- BƯỚC R10 (DEMO - tùy chọn, KHÔNG tự chạy khi cài đặt):
-- Khối này nằm trong /* ... */ nên khi @ cả script Oracle sẽ BỎ QUA.
-- Muốn demo: copy từng lệnh chạy tay theo đúng thứ tự (hoặc bỏ /* */).
--
-- Vì sao cần bước (b): bình thường VPD của bác sĩ (VPD_YC1C3_HSBA_BS) sẽ
-- tự thêm "AND MABS = user" nên BS0002 KHÔNG chạm được hồ sơ của BS0001
-- (câu lệnh 0 dòng -> không có gì để FGA ghi). Ta TẠM tắt policy đó + cấp
-- UPDATE để mô phỏng tình huống "hàng rào VPD bị lọt", cho câu lệnh trái
-- phép chạm tới bảng và bị FGA ghi nhận BATHOPPHAP. Sau đó BẬT LẠI ngay.
-- =======================================================================
/*
-- (a) [adminHos] Trạng thái GỐC của hồ sơ HSBA00101 (do BS0001 phụ trách)
CONNECT adminHos/123@localhost:1521/PDBHOSX
SELECT MAHSBA, CHANDOAN, KETLUAN FROM ADMINHOS.HSBA WHERE MAHSBA = 'HSBA00101';

-- (b) [adminHos] Mô phỏng "VPD bị lọt": tạm tắt policy BS trên HSBA + cấp UPDATE
BEGIN DBMS_RLS.ENABLE_POLICY('ADMINHOS', 'HSBA', 'VPD_YC1C3_HSBA_BS', FALSE); END;
/
GRANT UPDATE ON ADMINHOS.HSBA TO BS0002;

-- (c) [BS0002] KẺ TẤN CÔNG sửa trộm hồ sơ của BS0001 (mật khẩu mặc định: Hos@123456)
CONNECT BS0002/Hos@123456@localhost:1521/PDBHOSX
UPDATE ADMINHOS.HSBA
   SET CHANDOAN = N'BI SUA TRAI PHEP', KETLUAN = N'PHA HOAI'
 WHERE MAHSBA = 'HSBA00101';
COMMIT;

-- (d) [adminHos] BẬT LẠI hàng rào VPD + thu hồi quyền vừa cấp
CONNECT adminHos/123@localhost:1521/PDBHOSX
BEGIN DBMS_RLS.ENABLE_POLICY('ADMINHOS', 'HSBA', 'VPD_YC1C3_HSBA_BS', TRUE); END;
/
REVOKE UPDATE ON ADMINHOS.HSBA FROM BS0002;

-- (e) [adminHos] Xem sự cố đã được FGA ghi nhận (hoặc xem trên app: màn Kiểm toán)
SELECT DB_USER, OBJECT_NAME, POLICY_NAME, EXTENDED_TIMESTAMP
FROM   DBA_FGA_AUDIT_TRAIL
WHERE  OBJECT_NAME = 'HSBA' AND POLICY_NAME = 'FGA_HSBA_UPDATE_BATHOPPHAP'
ORDER BY EXTENDED_TIMESTAMP DESC;

-- (f) [adminHos] KHÔI PHỤC tự động dựa vào nhật ký kiểm toán
SET SERVEROUTPUT ON
DECLARE v_id VARCHAR2(50); v_st VARCHAR2(20); v_msg VARCHAR2(1000);
BEGIN
    ADMINHOS.SP_KHOIPHUC_TUDONG_THEO_AUDIT(v_id, v_st, v_msg);
    DBMS_OUTPUT.PUT_LINE('LOG_ID : ' || v_id);
    DBMS_OUTPUT.PUT_LINE('STATUS : ' || v_st);
    DBMS_OUTPUT.PUT_LINE('MESSAGE: ' || v_msg);
END;
/

-- (g) [adminHos] Kiểm tra: dữ liệu đã trở về như cũ
SELECT MAHSBA, CHANDOAN, KETLUAN FROM ADMINHOS.HSBA WHERE MAHSBA = 'HSBA00101';
*/


-- =======================================================================
-- =======================================================================
-- YÊU CẦU 4 - PHẦN 3 & 4: ĐÁNH GIÁ ƯU/KHUYẾT ĐIỂM VÀ KẾT LUẬN
-- (Phần lý thuyết, không thực thi - để trong block comment)
-- =======================================================================
-- =======================================================================
/*

=========================================================================
 1. TỔNG HỢP CÁC PHƯƠNG PHÁP ĐÃ TÌM HIỂU & HIỆN THỰC
=========================================================================
 A. RMAN (Recovery Manager)        - Sao lưu VẬT LÝ (physical): datafile,
                                      control file, archived redo log.
 B. Data Pump (expdp/impdp,        - Sao lưu LOGIC (logical) ở mức schema/
    DBMS_DATAPUMP)                   bảng (.dmp). Đã hiện thực CHỦ ĐỘNG
                                      (SP_RUN_DATAPUMP_BACKUP) và TỰ ĐỘNG
                                      (DBMS_SCHEDULER: JOB_DAILY_DATAPUMP_BACKUP).
 C. Oracle Flashback               - Phục hồi nhanh dựa trên UNDO/recycle bin:
    (Query/Table/Drop/Database)      Flashback Query (AS OF SCN/TIMESTAMP),
                                      Flashback Table, Flashback Drop,
                                      Flashback Database.
 D. KHÔI PHỤC DỰA VÀO NHẬT KÝ      - Kết hợp YC3 (FGA) + Flashback Query:
    KIỂM TOÁN (đã hiện thực)         đọc DBA_FGA_AUDIT_TRAIL -> lấy thời điểm
                                      sự cố -> TIMESTAMP_TO_SCN(t-1s) ->
                                      SELECT ... AS OF SCN -> MERGE/INSERT/
                                      DELETE hoàn tác. (SP_KHOIPHUC_*_THEO_AUDIT)

=========================================================================
 2. ĐÁNH GIÁ ƯU / KHUYẾT ĐIỂM TỪNG PHƯƠNG PHÁP
=========================================================================

 -----------------------------------------------------------------------
 A. RMAN (PHYSICAL BACKUP)
 -----------------------------------------------------------------------
 Ưu điểm:
   - Sao lưu/phục hồi ở mức TOÀN BỘ database, datafile, tablespace.
   - Hỗ trợ Point-In-Time Recovery (PITR) nhờ ARCHIVELOG: phục hồi tới
     đúng một mốc thời gian/SCN bất kỳ.
   - Backup gia tăng (incremental level 0/1), nén, kiểm tra tính hợp lệ
     (VALIDATE), tự quản lý qua catalog/control file.
   - Phù hợp thảm họa lớn: hỏng đĩa, mất file, crash instance.
 Khuyết điểm:
   - Nặng, phức tạp; chạy ở mức OS (command-line), khó gọi trực tiếp từ app.
   - Đòi hỏi cấu hình ARCHIVELOG, Fast Recovery Area, dung lượng lớn.
   - Phục hồi thường ở mức toàn DB -> "dùng dao mổ trâu" để sửa vài dòng
     bị hỏng; thời gian phục hồi (RTO) lâu.
   - Không phân biệt được "ai phá hoại" - chỉ đưa DB về mốc thời gian.

 -----------------------------------------------------------------------
 B. DATA PUMP (LOGICAL BACKUP) - CHỦ ĐỘNG & TỰ ĐỘNG
 -----------------------------------------------------------------------
 Ưu điểm:
   - Linh hoạt mức SCHEMA/BẢNG/đối tượng; file .dmp di chuyển được giữa
     các DB, khác nền tảng, khác phiên bản (version).
   - Có API PL/SQL (DBMS_DATAPUMP) -> gọi được TRỰC TIẾP từ trong DB và
     từ ứng dụng, lập lịch tự động bằng DBMS_SCHEDULER (sao lưu 02:00).
   - Nhẹ hơn RMAN cho việc sao lưu chọn lọc; có ghi BACKUP_LOG để theo dõi.
 Khuyết điểm:
   - Là ảnh chụp tại thời điểm export -> KHÔNG có PITR; dữ liệu phát sinh
     sau lần export gần nhất sẽ mất nếu phải phục hồi từ .dmp.
   - Phục hồi (impdp) có thể chậm với dữ liệu lớn; không thay thế được
     backup vật lý khi hỏng cấu trúc/đĩa.
   - Cần Oracle DIRECTORY + thư mục OS tồn tại; phụ thuộc lịch chạy job.

 -----------------------------------------------------------------------
 C. ORACLE FLASHBACK
 -----------------------------------------------------------------------
 Ưu điểm:
   - Phục hồi RẤT NHANH lỗi logic của người dùng (UPDATE/DELETE/DROP nhầm)
     mà KHÔNG cần restore từ file backup.
   - Nhiều mức: Flashback Query (xem/lấy lại dữ liệu quá khứ), Table
     (đưa bảng về quá khứ), Drop (khôi phục bảng đã DROP), Database.
   - Thao tác đơn giản bằng SQL; có thể nhắm đúng dòng/bảng cần.
 Khuyết điểm:
   - Phụ thuộc UNDO segment (UNDO_RETENTION) và recycle bin -> chỉ phục hồi
     trong CỬA SỔ thời gian giới hạn; quá hạn sẽ ORA-01555 (snapshot too old).
   - Flashback Database cần bật flashback logs (tốn dung lượng).
   - Không thay được backup khi hỏng vật lý datafile.
   - Tự bản thân Flashback KHÔNG biết "phục hồi tới mốc nào" - cần nguồn
     thông tin về thời điểm sự cố (đây là chỗ nhật ký kiểm toán bổ khuyết).

 -----------------------------------------------------------------------
 D. KHÔI PHỤC DỰA VÀO NHẬT KÝ KIỂM TOÁN (FGA + FLASHBACK QUERY)
 -----------------------------------------------------------------------
 Ưu điểm:
   - Đúng tinh thần đề: tận dụng YC3 (FGA) làm nguồn xác định CHÍNH XÁC
     thời điểm và đối tượng bị tấn công, rồi tự Flashback về trước sự cố.
   - Có chọn lọc: chỉ hoàn tác đúng các dòng bị sửa/xóa/chèn trái phép
     (hoàn tác cả UPDATE, INSERT, DELETE), ít ảnh hưởng dữ liệu hợp lệ.
   - Tự động hóa cao (1 lệnh gọi SP tổng), có ghi RECOVERY_LOG để truy vết,
     biến nhật ký GIÁM SÁT thành công cụ PHỤC HỒI.
   - Gắn kết YC3 và YC4 thành một quy trình "phát hiện -> khôi phục".
 Khuyết điểm:
   - Cũng phụ thuộc UNDO_RETENTION (vì dùng Flashback Query AS OF SCN)
     -> phải khôi phục SỚM sau sự cố, quá hạn thì không lấy lại được.
   - Chỉ khôi phục được những gì FGA có ghi nhận; nếu policy chưa bao phủ
     hành vi nào thì hành vi đó không được phát hiện để khôi phục.
   - Là cơ chế bù đắp ở tầng dữ liệu, không thay thế backup vật lý/logic
     cho thảm họa diện rộng.

=========================================================================
 3. BẢNG SO SÁNH TỔNG HỢP
=========================================================================
 Tiêu chí          | RMAN        | Data Pump   | Flashback   | Khôi phục
                   | (vật lý)    | (logic)     |             | theo Audit
 ------------------+-------------+-------------+-------------+-------------
 Mức tác động      | Toàn DB     | Schema/bảng | Dòng/bảng/DB| Dòng cụ thể
 PITR (mốc bất kỳ) | Có          | Không       | Trong UNDO  | Trong UNDO
 Phụ thuộc UNDO    | Không       | Không       | Có          | Có
 Tốc độ phục hồi   | Chậm        | Trung bình  | Rất nhanh   | Rất nhanh
 Gọi từ app/PLSQL  | Khó (OS)    | Dễ (API)    | Dễ (SQL)    | Dễ (SP)
 Tự động hóa       | Lịch RMAN   | Scheduler   | Thủ công    | 1 SP tổng
 Hỏng đĩa/file     | Cứu được    | Hạn chế     | Không       | Không
 Biết "mốc sự cố"? | Không       | Không       | Không tự    | CÓ (từ FGA)

=========================================================================
 4. KẾT LUẬN
=========================================================================
 - Không có MỘT phương pháp duy nhất là đủ; các phương pháp BỔ SUNG cho
   nhau theo nguyên tắc phòng vệ nhiều lớp:
     * RMAN (vật lý)  : lớp nền chống thảm họa hạ tầng (hỏng đĩa/file/crash),
                        cho phép PITR toàn hệ thống.
     * Data Pump      : sao lưu logic linh hoạt, CHỦ ĐỘNG + TỰ ĐỘNG (02:00),
                        dùng để di chuyển/khôi phục theo schema/bảng.
     * Flashback      : xử lý nhanh lỗi logic trong cửa sổ UNDO.
     * Khôi phục theo : đúng trọng tâm YC4 - dùng NHẬT KÝ KIỂM TOÁN (YC3) để
       nhật ký KT       phát hiện sự cố và Flashback CHÍNH XÁC phần bị tấn công.
 - Chiến lược của đồ án: dùng Data Pump cho sao lưu định kỳ (phòng ngừa),
   và Khôi phục-theo-Audit cho khắc phục sau sự cố bảo mật (phản ứng).
   RMAN/Flashback được trình bày như các lớp bổ trợ.
 - Khuyến nghị vận hành: bật ARCHIVELOG, đặt UNDO_RETENTION đủ dài, sao lưu
   định kỳ + kiểm tra khả năng phục hồi (restore test) thường xuyên, và
   chạy khôi-phục-theo-audit càng SỚM càng tốt sau khi phát hiện sự cố để
   dữ liệu còn trong cửa sổ Flashback.

*/


-- -------------------------------------------------------
-- KIỂM TRA KẾT QUẢ
-- -------------------------------------------------------
SET LINESIZE 130
COLUMN OBJECT_NAME FORMAT A42
COLUMN OBJECT_TYPE FORMAT A22
COLUMN STATUS      FORMAT A10

SELECT OBJECT_NAME, OBJECT_TYPE, STATUS
FROM   USER_OBJECTS
WHERE  OBJECT_NAME IN (
    'BACKUP_LOG','SEQ_BACKUP_LOG',
    'SP_RUN_DATAPUMP_BACKUP','SP_GET_BACKUP_HISTORY_APP',
    -- Khôi phục dựa vào nhật ký kiểm toán
    'RECOVERY_LOG','SEQ_RECOVERY_LOG','FN_GET_CLEAN_SCN',
    'SP_KHOIPHUC_HSBA_THEO_AUDIT','SP_KHOIPHUC_HSBA_DV_THEO_AUDIT',
    'SP_KHOIPHUC_DONTHUOC_THEO_AUDIT','SP_KHOIPHUC_TUDONG_THEO_AUDIT',
    'SP_GET_SUCO_FROM_AUDIT','SP_GET_RECOVERY_HISTORY'
)
ORDER BY OBJECT_TYPE, OBJECT_NAME;

COLUMN DIRECTORY_NAME FORMAT A30
COLUMN DIRECTORY_PATH FORMAT A70

SELECT DIRECTORY_NAME, DIRECTORY_PATH
FROM   DBA_DIRECTORIES
WHERE  DIRECTORY_NAME IN ('HOSPITALX_BACKUP_DIR','DATA_PUMP_DIR')
ORDER BY DIRECTORY_NAME;

EXIT;

