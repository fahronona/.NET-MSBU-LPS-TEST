CREATE DEFINER=`root`@`localhost` PROCEDURE `MSBU_LPS_DBTEST`.`SearchProduk`(
    IN p_nama_barang VARCHAR(200)
)
BEGIN
    SELECT * FROM produk WHERE nama_barang LIKE CONCAT('%', p_nama_barang, '%');
END