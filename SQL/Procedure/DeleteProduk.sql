CREATE DEFINER=`root`@`localhost` PROCEDURE `MSBU_LPS_DBTEST`.`DeleteProduk`(
    IN p_id INT
)
BEGIN
    DELETE FROM produk WHERE id = p_id;
END