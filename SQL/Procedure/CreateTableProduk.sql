CREATE TABLE Produk (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nama_barang VARCHAR(200) NOT NULL,
    kode_barang VARCHAR(50) NOT NULL,
    jumlah_barang INT NOT NULL,
    tanggal DATETIME NOT NULL);

