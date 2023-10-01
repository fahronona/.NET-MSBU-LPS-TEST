CREATE DEFINER=`root`@`localhost` PROCEDURE `MSBU_LPS_DBTEST`.`UpdateProduk`(
    IN p_id INT,
    IN p_nama_barang VARCHAR(200),
    IN p_kode_barang VARCHAR(50),
    IN p_jumlah_barang INT,
    IN p_tanggal DATETIME
)
BEGIN
    UPDATE produk
    SET
        nama_barang = p_nama_barang,
        kode_barang = p_kode_barang,
        jumlah_barang = p_jumlah_barang,
        tanggal = p_tanggal
    WHERE id = p_id;
END