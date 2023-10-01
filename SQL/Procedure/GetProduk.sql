CREATE DEFINER=`root`@`localhost` PROCEDURE `MSBU_LPS_DBTEST`.`GetProduk`()
BEGIN
    SELECT * FROM produk;
END