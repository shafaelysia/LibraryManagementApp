-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 30, 2023 at 01:40 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbperpus`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `kode_admin` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telp` varchar(20) NOT NULL,
  `jenis_kelamin` char(1) NOT NULL,
  `tgl_lahir` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`kode_admin`, `nama`, `username`, `password`, `email`, `telp`, `jenis_kelamin`, `tgl_lahir`) VALUES
(1, 'Admin 01', 'admin01', 'perpus', 'admin01@gmail.com', '08123456789', 'L', '1990-07-20'),
(2, 'Admin 03', 'admin03\r\n           ', 'perpus', 'admin03@gmail.com', '089182346109', 'P', '2000-05-18'),
(3, 'A', 'A', 'A', 'A@gmail.com', '081112313', 'P', '1995-10-25'),
(4, 'B', 'B', 'B', 'B@gmail.com', '0123456789', 'L', '2004-04-04'),
(5, 'test', 'test', 'test', 'test@gmail.com', '08716729', 'L', '1999-11-27'),
(6, 'C', 'C', 'C', 'C', '0812893462', 'P', '1992-12-04'),
(7, '', '', '', '', '', '', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `anggota`
--

CREATE TABLE `anggota` (
  `kode_anggota` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telp` varchar(20) NOT NULL,
  `jenis_kelamin` char(1) NOT NULL,
  `tgl_lahir` date NOT NULL,
  `tgl_bergabung` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `anggota`
--

INSERT INTO `anggota` (`kode_anggota`, `nama`, `email`, `telp`, `jenis_kelamin`, `tgl_lahir`, `tgl_bergabung`) VALUES
(1, 'Anggota 01', 'anggota01@gmail.com', '08337642591', 'P', '2000-11-01', '0000-00-00'),
(2, 'Anggota 02', 'anggota02@gmail.com', '0896247815', 'L', '2001-07-22', '2010-11-09'),
(3, 'test', 'test@gmail.com', '08123445902', 'L', '1997-10-12', '2010-05-20'),
(4, 'A', 'A', '089417129', 'P', '1998-04-22', '2015-10-17');

-- --------------------------------------------------------

--
-- Table structure for table `buku`
--

CREATE TABLE `buku` (
  `kode_buku` int(11) NOT NULL,
  `judul` varchar(255) NOT NULL,
  `penulis` varchar(255) NOT NULL,
  `penerbit` varchar(100) NOT NULL,
  `bahasa` varchar(100) NOT NULL,
  `jml_hal` int(20) NOT NULL,
  `tgl_terbit` date NOT NULL,
  `lokasi` varchar(20) NOT NULL,
  `ketersediaan` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `buku`
--

INSERT INTO `buku` (`kode_buku`, `judul`, `penulis`, `penerbit`, `bahasa`, `jml_hal`, `tgl_terbit`, `lokasi`, `ketersediaan`) VALUES
(1, 'Rumah Hujan', 'Dewi Ria Utari', 'Gramedia Pustaka Utama', 'Indonesia', 216, '2020-04-12', 'A-101', 'Tersedia'),
(2, 'Matahari Minor', 'Tere Liye', 'PENERBIT SABAK GRIP', 'Indonesia', 361, '2022-10-27', 'A-102', 'Tersedia'),
(3, 'Sang Pemimpi', 'Andrea Hirata', 'Bentang Pustaka', 'Indonesia', 276, '2020-02-01', 'A-103', 'Tersedia'),
(4, 'Metropop: Finn', 'Honey Dee', 'Gramedia Pustaka Utama', 'Indonesia', 316, '2020-01-12', 'A-104', 'Tersedia'),
(5, 'Sunshine Becomes You', 'Ilana Tan', 'Gramedia Pustaka Utama', 'Indonesia', 432, '2021-04-27', 'A-105', 'Tersedia'),
(6, 'test', 'test', 'test', 'test', 111, '0000-00-00', 'A-test', 'Tidak Tersedia');

-- --------------------------------------------------------

--
-- Table structure for table `peminjaman`
--

CREATE TABLE `peminjaman` (
  `kode_peminjaman` int(11) NOT NULL,
  `kode_buku` int(11) NOT NULL,
  `kode_anggota` int(11) NOT NULL,
  `anggota` varchar(100) NOT NULL,
  `judul` varchar(255) NOT NULL,
  `penulis` varchar(25) NOT NULL,
  `tgl_peminjaman` date NOT NULL,
  `tgl_pengembalian` date NOT NULL,
  `status` tinyint(1) NOT NULL,
  `tgl_dikembalikan` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `peminjaman`
--

INSERT INTO `peminjaman` (`kode_peminjaman`, `kode_buku`, `kode_anggota`, `anggota`, `judul`, `penulis`, `tgl_peminjaman`, `tgl_pengembalian`, `status`, `tgl_dikembalikan`) VALUES
(1, 1, 1, 'Anggota 01', 'Rumah Hujan', 'Dewi Ria Utari', '2023-01-02', '2023-01-16', 1, '2023-01-10'),
(2, 3, 3, 'test', 'Sang Pemimpi', 'Andrea Hirata', '2022-12-12', '2022-12-26', 1, '2022-12-25'),
(3, 4, 1, 'Anggota 01', 'Metropop: Finn', 'Honey Dee', '2022-12-12', '2022-12-26', 1, '2022-12-24'),
(10, 7, 4, 'A', 'A', 'A', '2023-01-15', '2023-01-29', 1, '2023-02-01'),
(11, 6, 3, 'test', 'test', 'test', '2023-01-20', '2023-02-06', 0, NULL),
(13, 7, 4, 'A', 'A', 'A', '2020-01-01', '2021-01-01', 0, NULL),
(14, 5, 2, 'Anggota 02', 'Ilana Tan', 'Ilana Tan', '2023-02-10', '2023-02-17', 1, '1012-01-11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`kode_admin`);

--
-- Indexes for table `anggota`
--
ALTER TABLE `anggota`
  ADD PRIMARY KEY (`kode_anggota`);

--
-- Indexes for table `buku`
--
ALTER TABLE `buku`
  ADD PRIMARY KEY (`kode_buku`);

--
-- Indexes for table `peminjaman`
--
ALTER TABLE `peminjaman`
  ADD PRIMARY KEY (`kode_peminjaman`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `kode_admin` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `anggota`
--
ALTER TABLE `anggota`
  MODIFY `kode_anggota` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `buku`
--
ALTER TABLE `buku`
  MODIFY `kode_buku` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `peminjaman`
--
ALTER TABLE `peminjaman`
  MODIFY `kode_peminjaman` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
