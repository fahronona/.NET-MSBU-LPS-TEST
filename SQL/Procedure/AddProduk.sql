CREATE DEFINER=`root`@`localhost` PROCEDURE `MSBU_LPS_DBTEST`.`AddProduk`(
    IN p_nama_barang VARCHAR(200),
    IN p_kode_barang VARCHAR(50),
    IN p_jumlah_barang INT,
    IN p_tanggal DATETIME
)
BEGIN
    INSERT INTO Produk (nama_barang, kode_barang, jumlah_barang, tanggal)
    VALUES (p_nama_barang, p_kode_barang, p_jumlah_barang, p_tanggal);
END