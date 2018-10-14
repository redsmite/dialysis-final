-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 14, 2018 at 06:41 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `db_dialysis`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_adjustment`
--

CREATE TABLE IF NOT EXISTS `tbl_adjustment` (
  `adjust_id` int(11) NOT NULL AUTO_INCREMENT,
  `inventory_id` int(11) NOT NULL,
  `payment_id` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`adjust_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `tbl_adjustment`
--

INSERT INTO `tbl_adjustment` (`adjust_id`, `inventory_id`, `payment_id`, `price`) VALUES
(1, 1, 5, '1850.00'),
(2, 2, 5, '3320.00'),
(3, 3, 5, '2000.00'),
(4, 5, 5, '2000.00'),
(5, 10, 5, '2000.00'),
(6, 74, 5, '1000.00'),
(7, 75, 5, '1700.00'),
(8, 76, 5, '925.00'),
(9, 77, 5, '875.00'),
(10, 78, 5, '950.00'),
(11, 79, 5, '2000.00');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_category`
--

CREATE TABLE IF NOT EXISTS `tbl_category` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category` varchar(100) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `tbl_category`
--

INSERT INTO `tbl_category` (`category_id`, `category`) VALUES
(1, 'Dialyzer'),
(2, 'Laboratory'),
(3, 'Epoetin'),
(4, 'Meds / Supply'),
(5, 'Other Fees');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_changelog`
--

CREATE TABLE IF NOT EXISTS `tbl_changelog` (
  `log_id` int(11) NOT NULL AUTO_INCREMENT,
  `inventory_id` int(11) NOT NULL,
  `date_commit` datetime NOT NULL,
  `log` varchar(150) NOT NULL,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=256 ;

--
-- Dumping data for table `tbl_changelog`
--

INSERT INTO `tbl_changelog` (`log_id`, `inventory_id`, `date_commit`, `log`) VALUES
(1, 3, '2018-10-10 15:32:07', 'Add 210HR'),
(2, 4, '2018-10-10 15:33:41', 'Add 170L'),
(3, 5, '2018-10-10 15:34:13', 'Add 190LR'),
(4, 6, '2018-10-10 15:39:13', 'Add F8+'),
(5, 7, '2018-10-10 15:39:57', 'Add F80+'),
(6, 8, '2018-10-10 15:40:32', 'Add 210HR+'),
(7, 9, '2018-10-10 15:41:09', 'Add 190LR+'),
(8, 10, '2018-10-10 15:41:35', 'Add 190HR+'),
(9, 11, '2018-10-10 15:42:02', 'Add Lab 1 (CBC;Creatinine;Pre & Post BUN;Ca;K;P;Albumin;Na;BUA;URR & KT/V)'),
(10, 12, '2018-10-10 15:42:51', 'Add Lab 2 (Lab 1; SGPT;Alkaline Phospate;FBS;Lipid Profile)'),
(11, 13, '2018-10-10 15:43:26', 'Add Lab 3 (HbsAg;anti-HBs w/ titer;anti-HCV)'),
(12, 1, '2018-10-10 21:24:09', 'Change quantity to 4'),
(13, 1, '2018-10-10 21:24:09', 'Change price to  1600.00'),
(14, 1, '2018-10-10 21:29:01', 'Change quantity to 3'),
(15, 1, '2018-10-10 21:31:11', 'Change quantity to 4'),
(16, 1, '2018-10-10 21:31:11', 'Change price to  1600.00'),
(17, 1, '2018-10-10 21:33:03', 'Change quantity to 5'),
(18, 1, '2018-10-10 21:33:05', 'Change price to  1600.00'),
(19, 1, '2018-10-10 21:34:15', 'Change quantity to 6'),
(20, 1, '2018-10-10 21:34:18', 'Change price to  1600.00'),
(21, 1, '2018-10-10 21:36:49', 'Change quantity to 4'),
(22, 1, '2018-10-10 21:36:57', 'Change price to  1600.00'),
(23, 1, '2018-10-10 21:38:04', 'Change quantity to 5'),
(24, 1, '2018-10-10 21:38:07', 'Change price to  1600.00'),
(25, 1, '2018-10-10 21:39:30', 'Change quantity to 4'),
(26, 2, '2018-10-10 21:40:28', 'Change price to  2950.00'),
(27, 2, '2018-10-10 21:40:55', 'Change price to  2850.00'),
(28, 6, '2018-10-10 22:02:15', 'Change price to  1200.00'),
(29, 7, '2018-10-10 22:02:52', 'Change price to  120.00'),
(30, 8, '2018-10-10 22:03:38', 'Change quantity to 2'),
(31, 8, '2018-10-10 22:03:38', 'Change price to  90.00'),
(32, 9, '2018-10-10 22:04:18', 'Change quantity to 1'),
(33, 9, '2018-10-10 22:04:18', 'Change price to  90.00'),
(34, 14, '2018-10-10 22:05:11', 'Add Potassium'),
(35, 15, '2018-10-10 22:05:32', 'Add Albumin'),
(36, 16, '2018-10-10 22:06:07', 'Add FBS'),
(37, 17, '2018-10-10 22:06:25', 'Add BUA'),
(38, 18, '2018-10-10 22:06:43', 'Add SGPT'),
(39, 19, '2018-10-10 22:06:59', 'Add SGOT'),
(40, 20, '2018-10-10 22:07:23', 'Add Phosphorus'),
(41, 21, '2018-10-10 22:07:51', 'Add HbsAg'),
(42, 22, '2018-10-10 22:08:12', 'Add Anti-HBs'),
(43, 23, '2018-10-10 22:08:35', 'Add Anti-HCV'),
(44, 24, '2018-10-10 22:09:08', 'Add Calcium (Ionized)/ Total'),
(45, 25, '2018-10-10 22:10:03', 'Add Total Cholesterol'),
(46, 26, '2018-10-10 22:10:31', 'Add HDL'),
(47, 27, '2018-10-10 22:12:47', 'Add LDL'),
(48, 28, '2018-10-10 22:13:11', 'Add Triglycerides'),
(49, 29, '2018-10-10 22:13:26', 'Add Magnesium /Mg'),
(50, 30, '2018-10-10 22:13:43', 'Add Sodium'),
(51, 31, '2018-10-10 22:13:55', 'Add Chloride'),
(52, 32, '2018-10-10 22:14:08', 'Add SGOT / AST'),
(53, 33, '2018-10-10 22:14:23', 'Add SGPT / ALT'),
(54, 34, '2018-10-10 22:14:43', 'Add Bilirubin(tb;b1;b2)'),
(55, 35, '2018-10-10 22:15:08', 'Add GGT'),
(56, 36, '2018-10-10 22:15:34', 'Add Alkaline Phosphatase / ALP'),
(57, 37, '2018-10-10 22:15:48', 'Add Total Protein'),
(58, 38, '2018-10-10 22:16:03', 'Add HbA1C /Glycosylated Hgb'),
(59, 39, '2018-10-10 22:16:27', 'Add TPAG'),
(60, 40, '2018-10-10 22:16:50', 'Add PSA'),
(61, 41, '2018-10-10 22:17:02', 'Add Gram Stain'),
(62, 42, '2018-10-10 22:17:53', 'Add AFB x3'),
(63, 43, '2018-10-10 22:18:05', 'Add Lipid Profile'),
(64, 44, '2018-10-10 22:18:20', 'Add Na;K;iCal'),
(65, 45, '2018-10-10 22:18:32', 'Add ASO'),
(66, 46, '2018-10-10 22:18:55', 'Add OGCT'),
(67, 47, '2018-10-10 22:20:09', 'Add CBC w/ Plate Count'),
(68, 48, '2018-10-10 22:20:21', 'Add Platelet count'),
(69, 49, '2018-10-10 22:20:36', 'Add ABO w/ Rh typing'),
(70, 50, '2018-10-10 22:20:53', 'Add ESR'),
(71, 51, '2018-10-10 22:21:06', 'Add Bleeding Time'),
(72, 52, '2018-10-10 22:21:21', 'Add Clotting Time'),
(73, 53, '2018-10-10 22:21:35', 'Add APTT'),
(74, 54, '2018-10-10 22:21:53', 'Add Prothrombin Time / PTPA'),
(75, 55, '2018-10-10 22:22:08', 'Add Peripheral Blood Smear'),
(76, 56, '2018-10-10 22:22:23', 'Add Routine Urinalysis'),
(77, 57, '2018-10-10 22:22:45', 'Add Fecalysis'),
(78, 58, '2018-10-10 22:23:47', 'Add Fecalysis w/ Occult Blood'),
(79, 35, '2018-10-10 22:24:08', 'Change quantity to 0'),
(80, 40, '2018-10-10 22:24:18', 'Change quantity to 0'),
(81, 41, '2018-10-10 22:24:28', 'Change quantity to 0'),
(82, 56, '2018-10-10 22:24:37', 'Change quantity to 0'),
(83, 57, '2018-10-10 22:24:49', 'Change quantity to 0'),
(84, 59, '2018-10-10 22:25:17', 'Add Pregnancy Test'),
(85, 60, '2018-10-10 22:25:40', 'Add Iron'),
(86, 61, '2018-10-10 22:26:09', 'Add Ferritin'),
(87, 62, '2018-10-10 22:27:10', 'Add Anti-HAV (IgM)'),
(88, 63, '2018-10-10 22:27:21', 'Add Anti-Hbe'),
(89, 64, '2018-10-10 22:27:30', 'Add Anti- Hbc (Total)'),
(90, 65, '2018-10-10 22:27:51', 'Add T3'),
(91, 66, '2018-10-10 22:28:17', 'Add T4'),
(92, 67, '2018-10-10 22:28:35', 'Add TSH'),
(93, 68, '2018-10-10 22:29:00', 'Add FT3'),
(94, 69, '2018-10-10 22:29:12', 'Add FT4'),
(95, 70, '2018-10-10 22:29:23', 'Add Bicarbonate'),
(96, 71, '2018-10-10 22:29:36', 'Add PTH'),
(97, 72, '2018-10-10 22:29:46', 'Add Tumor Marker'),
(98, 73, '2018-10-10 22:29:59', 'Add TIBC'),
(99, 74, '2018-10-10 22:30:29', 'Add Eprex'),
(100, 75, '2018-10-10 22:30:55', 'Add Recormon'),
(101, 76, '2018-10-10 22:31:12', 'Add Renogen'),
(102, 77, '2018-10-10 22:31:30', 'Add Eposino'),
(103, 78, '2018-10-10 22:31:46', 'Add Hemapo'),
(104, 79, '2018-10-10 22:32:12', 'Add NESP darbepoetin alfa'),
(105, 80, '2018-10-10 22:32:39', 'Add 0K (acid bath)'),
(106, 81, '2018-10-10 22:33:10', 'Add 5% Dextrose'),
(107, 80, '2018-10-10 22:33:20', 'Change quantity to 20'),
(108, 82, '2018-10-10 22:34:00', 'Add Aborted TX'),
(109, 83, '2018-10-10 22:34:16', 'Add Alcohol pads'),
(110, 84, '2018-10-10 22:34:35', 'Add Ambulance 1'),
(111, 85, '2018-10-10 22:34:52', 'Add Ambulance 2'),
(112, 86, '2018-10-10 22:35:22', 'Add Amiodarone 150mg'),
(113, 87, '2018-10-10 22:35:37', 'Add Antamine'),
(114, 88, '2018-10-10 22:35:49', 'Add Asepto Syringe'),
(115, 89, '2018-10-10 22:36:05', 'Add Aspirin 80mg'),
(116, 90, '2018-10-10 22:36:25', 'Add Atropine Sulfate'),
(117, 91, '2018-10-10 22:36:40', 'Add AV Fistula'),
(118, 92, '2018-10-10 22:37:08', 'Add BCM Electrodes'),
(119, 93, '2018-10-10 22:37:24', 'Add Benadryl 50mg cap'),
(120, 94, '2018-10-10 22:37:41', 'Add Beta Pad'),
(121, 95, '2018-10-10 22:37:59', 'Add Bloodline set'),
(122, 96, '2018-10-10 22:38:14', 'Add Bricanyl tab'),
(123, 97, '2018-10-10 22:38:32', 'Add BT charge'),
(124, 98, '2018-10-10 22:38:56', 'Add BT Set'),
(125, 99, '2018-10-10 22:39:13', 'Add BT Set+Benadryl'),
(126, 100, '2018-10-10 22:39:30', 'Add Buscopan 10mg tab'),
(127, 101, '2018-10-10 22:39:51', 'Add Buscopan amp'),
(128, 102, '2018-10-10 22:40:09', 'Add Ca Gluconate 100mg/ml'),
(129, 103, '2018-10-10 22:40:32', 'Add Calcium Gloconate'),
(130, 104, '2018-10-10 22:41:02', 'Add Cath hep'),
(131, 105, '2018-10-10 22:41:27', 'Add Clonipres 150mg'),
(132, 106, '2018-10-10 22:41:42', 'Add Clonipres 75mg'),
(133, 107, '2018-10-10 22:41:58', 'Add Combivent Nebule'),
(134, 108, '2018-10-10 22:42:12', 'Add D5 NM'),
(135, 109, '2018-10-10 22:42:46', 'Add Dextrose 50%/50ml'),
(136, 110, '2018-10-10 22:43:03', 'Add Diazepam 10 Tab'),
(137, 111, '2018-10-10 22:43:17', 'Add Diazepam 5 Tab'),
(138, 112, '2018-10-10 22:43:36', 'Add Diazepam Amp'),
(139, 113, '2018-10-10 22:43:52', 'Add Diphenhydramine'),
(140, 114, '2018-10-10 22:44:13', 'Add Dobutamine'),
(141, 115, '2018-10-10 22:44:28', 'Add Dolfenal Mefenamic'),
(142, 116, '2018-10-10 22:44:50', 'Add Dopamine amp'),
(143, 117, '2018-10-10 22:45:09', 'Add Dormicum/Midazolam'),
(144, 118, '2018-10-10 22:45:26', 'Add ECG'),
(145, 119, '2018-10-10 22:45:40', 'Add Epinephrine'),
(146, 120, '2018-10-10 22:46:00', 'Add ET Tube'),
(147, 121, '2018-10-10 22:46:15', 'Add Extra Heparin'),
(148, 122, '2018-10-10 22:46:27', 'Add Extra TX'),
(149, 123, '2018-10-10 22:46:46', 'Add Extra TX HMO'),
(150, 124, '2018-10-10 22:46:58', 'Add Face Mask'),
(151, 125, '2018-10-10 22:47:12', 'Add Ferrofer'),
(152, 126, '2018-10-10 22:47:32', 'Add Fistula Kit'),
(153, 127, '2018-10-10 22:47:50', 'Add Fucidin ointment'),
(154, 128, '2018-10-10 22:48:07', 'Add Furosemide/Lasix'),
(155, 129, '2018-10-10 22:48:20', 'Add G 7.0 ET Tube'),
(156, 130, '2018-10-10 22:48:30', 'Add G 7.5 ET Tube'),
(157, 131, '2018-10-10 22:48:51', 'Add G 8.0 ET Tube'),
(158, 132, '2018-10-10 22:49:05', 'Add G16 catheter'),
(159, 133, '2018-10-10 22:49:26', 'Add G20 catheter'),
(160, 134, '2018-10-10 22:49:42', 'Add G22 catheter'),
(161, 135, '2018-10-10 22:49:59', 'Add G24 catheter'),
(162, 136, '2018-10-10 22:50:12', 'Add gauze 2x2'),
(163, 137, '2018-10-10 22:50:25', 'Add gauze 4x4'),
(164, 138, '2018-10-10 22:50:41', 'Add Gentamicin 80mg/2ml'),
(165, 139, '2018-10-10 22:51:05', 'Add Gloves'),
(166, 140, '2018-10-10 22:51:26', 'Add Hemostan'),
(167, 141, '2018-10-10 22:51:38', 'Add Hemostan Amp'),
(168, 142, '2018-10-10 22:51:57', 'Add Heparin vial'),
(169, 143, '2018-10-10 22:52:11', 'Add Heplock'),
(170, 144, '2018-10-10 22:52:31', 'Add HGT Strips'),
(171, 145, '2018-10-10 22:52:46', 'Add Hydrocort 100mg'),
(172, 146, '2018-10-10 22:53:00', 'Add Hydrocort 250mg'),
(173, 147, '2018-10-10 22:53:17', 'Add IJ Flushing'),
(174, 148, '2018-10-10 22:53:30', 'Add Immodium 2mg cap'),
(175, 149, '2018-10-10 22:53:48', 'Add Inohep 2ml vial'),
(176, 150, '2018-10-10 22:54:02', 'Add Isordil 10mg Tab'),
(177, 151, '2018-10-10 22:54:18', 'Add Isordil 5mg Sub'),
(178, 152, '2018-10-10 22:54:38', 'Add IV Cath G20,22'),
(179, 153, '2018-10-10 22:54:52', 'Add IV Fe Charge'),
(180, 154, '2018-10-10 22:55:04', 'Add Kalimate 5g'),
(181, 155, '2018-10-10 22:55:22', 'Add Ketobest 600mg'),
(182, 156, '2018-10-10 22:55:36', 'Add Lanoxin amp'),
(183, 157, '2018-10-10 22:55:52', 'Add Lanoxin Tab'),
(184, 158, '2018-10-10 22:56:12', 'Add Lidocaine /cc'),
(185, 159, '2018-10-10 22:56:27', 'Add Macroset'),
(186, 160, '2018-10-10 22:56:40', 'Add Mannitol'),
(187, 161, '2018-10-10 22:57:00', 'Add Mefenamic Acid 500mg'),
(188, 162, '2018-10-10 22:57:15', 'Add Micropore'),
(189, 163, '2018-10-10 22:57:28', 'Add Microset'),
(190, 164, '2018-10-10 22:57:53', 'Add misc fee'),
(191, 164, '2018-10-10 22:58:07', 'Change quantity to 1'),
(192, 165, '2018-10-10 22:58:39', 'Add Na Bicarb (8.4%) 10ml'),
(193, 166, '2018-10-10 22:58:56', 'Add Na Bicarb (8.4%) 50ml'),
(194, 167, '2018-10-10 22:59:15', 'Add NaCl (9%) 50ml'),
(195, 168, '2018-10-10 22:59:30', 'Add Neb Kit'),
(196, 169, '2018-10-10 22:59:50', 'Add NGT Tube'),
(197, 170, '2018-10-10 23:00:07', 'Add Nicardipine amp'),
(198, 171, '2018-10-10 23:00:21', 'Add Nifedipine 5mg'),
(199, 172, '2018-10-10 23:00:40', 'Add Nitroglycerin Patch'),
(200, 173, '2018-10-10 23:00:56', 'Add NSS (0.9 %)'),
(201, 174, '2018-10-10 23:01:09', 'Add O2 Cannula'),
(202, 175, '2018-10-10 23:01:22', 'Add O2 Inhalation /30min'),
(203, 176, '2018-10-10 23:01:39', 'Add O2 Mask'),
(204, 177, '2018-10-10 23:01:58', 'Add OR Fee'),
(205, 178, '2018-10-10 23:02:36', 'Add Paracetamol amp'),
(206, 179, '2018-10-10 23:02:52', 'Add Paracetamol Tab'),
(207, 180, '2018-10-10 23:03:10', 'Add Plasil Amp'),
(208, 181, '2018-10-10 23:03:36', 'Add Plasil Tab'),
(209, 182, '2018-10-10 23:03:53', 'Add Ponstant Mefenamic'),
(210, 183, '2018-10-10 23:04:10', 'Add Potassium Chloride 20ml'),
(211, 184, '2018-10-10 23:04:22', 'Add Ranitidine Amp'),
(212, 185, '2018-10-10 23:04:36', 'Add Ranitidine Tab'),
(213, 186, '2018-10-10 23:04:56', 'Add Renvela'),
(214, 187, '2018-10-10 23:05:24', 'Add Retic Count'),
(215, 188, '2018-10-10 23:05:43', 'Add Ribotril'),
(216, 189, '2018-10-10 23:06:05', 'Add Sodium Chloride'),
(217, 190, '2018-10-10 23:06:18', 'Add Solu Set'),
(218, 191, '2018-10-10 23:06:33', 'Add Suction Catheter'),
(219, 192, '2018-10-10 23:06:48', 'Add Suction Tip G16'),
(220, 193, '2018-10-10 23:07:08', 'Add Suture'),
(221, 194, '2018-10-10 23:07:28', 'Add Syringe 10cc'),
(222, 195, '2018-10-10 23:07:47', 'Add Syringe 1cc'),
(223, 196, '2018-10-10 23:08:37', 'Add Syringe 20cc'),
(224, 197, '2018-10-10 23:08:52', 'Add Syringe 3cc'),
(225, 198, '2018-10-10 23:09:13', 'Add Tram cetra'),
(226, 199, '2018-10-10 23:09:41', 'Add Tram dolcet'),
(227, 200, '2018-10-10 23:10:02', 'Add Tramadol amp'),
(228, 201, '2018-10-10 23:10:20', 'Add Underpads'),
(229, 202, '2018-10-10 23:10:42', 'Add vaccine(FLU)'),
(230, 203, '2018-10-10 23:11:03', 'Add vaccine(pneumo)'),
(231, 204, '2018-10-10 23:11:16', 'Add Wound dressing'),
(232, 205, '2018-10-10 23:11:35', 'Add Tegaderm'),
(233, 206, '2018-10-10 23:11:52', 'Add Nephrisol D'),
(234, 207, '2018-10-10 23:12:14', 'Add H & H strip'),
(235, 10, '2018-10-11 01:33:59', 'Change price to  1850.00'),
(236, 200, '2018-10-12 02:55:20', 'Change quantity to 4'),
(237, 179, '2018-10-12 02:58:47', 'Change quantity to 39'),
(238, 195, '2018-10-12 03:05:52', 'Change quantity to 99'),
(239, 195, '2018-10-12 03:12:24', 'Change quantity to 98'),
(240, 195, '2018-10-12 03:16:14', 'Change quantity to 97'),
(241, 195, '2018-10-12 03:24:10', 'Change quantity to 96'),
(242, 195, '2018-10-12 03:37:51', 'Change quantity to 95'),
(243, 195, '2018-10-12 03:47:38', 'Change quantity to 94'),
(244, 0, '2018-10-12 04:17:58', 'Change quantity to 93'),
(245, 0, '2018-10-12 04:18:23', 'Change quantity to 37'),
(246, 0, '2018-10-12 04:25:03', 'Change quantity to 93'),
(247, 0, '2018-10-12 04:25:17', 'Change quantity to 49'),
(248, 0, '2018-10-12 04:27:51', 'Change quantity to 93'),
(249, 195, '2018-10-12 04:32:37', 'Change quantity to 93'),
(250, 83, '2018-10-12 04:32:55', 'Change quantity to 49'),
(251, 195, '2018-10-12 14:14:11', 'Change quantity to 92'),
(252, 94, '2018-10-12 15:18:11', 'Change quantity to 49'),
(253, 111, '2018-10-12 15:18:23', 'Change quantity to 24'),
(254, 179, '2018-10-12 15:20:42', 'Change quantity to 38'),
(255, 195, '2018-10-12 15:20:52', 'Change quantity to 91');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_civil_status`
--

CREATE TABLE IF NOT EXISTS `tbl_civil_status` (
  `civil_status_id` int(11) NOT NULL AUTO_INCREMENT,
  `civil_status` varchar(10) NOT NULL,
  PRIMARY KEY (`civil_status_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `tbl_civil_status`
--

INSERT INTO `tbl_civil_status` (`civil_status_id`, `civil_status`) VALUES
(1, 'single'),
(2, 'married'),
(3, 'widowed'),
(4, 'divorced');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_gender`
--

CREATE TABLE IF NOT EXISTS `tbl_gender` (
  `gender_id` int(11) NOT NULL AUTO_INCREMENT,
  `gender` varchar(10) NOT NULL,
  PRIMARY KEY (`gender_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `tbl_gender`
--

INSERT INTO `tbl_gender` (`gender_id`, `gender`) VALUES
(1, 'male'),
(2, 'female');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_inventory`
--

CREATE TABLE IF NOT EXISTS `tbl_inventory` (
  `inventory_id` int(11) NOT NULL AUTO_INCREMENT,
  `inventory` varchar(100) NOT NULL,
  `category_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `description` varchar(255) NOT NULL,
  `is_consumable` tinyint(1) NOT NULL,
  `is_available` tinyint(1) NOT NULL,
  PRIMARY KEY (`inventory_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=208 ;

--
-- Dumping data for table `tbl_inventory`
--

INSERT INTO `tbl_inventory` (`inventory_id`, `inventory`, `category_id`, `quantity`, `price`, `description`, `is_consumable`, `is_available`) VALUES
(1, 'F8', 1, 4, '1600.00', 'F8 Dialyzer', 0, 1),
(2, 'F80', 1, 4, '2850.00', 'F80 Dialyzer', 0, 1),
(3, '210HR', 1, 2, '1850.00', '210HR Dialyzer', 0, 1),
(4, '170L', 1, 2, '900.00', '170L', 0, 1),
(5, '190LR', 1, 3, '1500.00', '190LR', 0, 1),
(6, 'Lab 7 (Iron;Ferritin;TIBC;TSAT)', 2, 2, '1200.00', 'Lab', 0, 1),
(7, 'CBC', 2, 1, '120.00', 'Lab', 0, 1),
(8, 'Creatinine', 2, 2, '90.00', 'Lab', 0, 1),
(9, 'BUN', 2, 1, '90.00', 'Lab', 0, 1),
(10, '190HR', 1, 3, '1850.00', 'Dialyzer', 0, 1),
(11, 'Lab 1 (CBC;Creatinine;Pre & Post BUN;Ca;K;P;Albumin;Na;BUA;URR & KT/V)', 2, 1, '750.00', 'Lab', 0, 1),
(12, 'Lab 2 (Lab 1; SGPT;Alkaline Phospate;FBS;Lipid Profile)', 2, 1, '1100.00', 'Lab', 0, 1),
(13, 'Lab 3 (HbsAg;anti-HBs w/ titer;anti-HCV)', 2, 1, '900.00', 'Lab', 0, 1),
(14, 'Potassium', 2, 5, '135.00', 'Lab', 1, 1),
(15, 'Albumin', 2, 2, '95.00', 'Lab', 1, 1),
(16, 'FBS', 2, 3, '90.00', 'Lab', 1, 1),
(17, 'BUA', 2, 2, '95.00', 'Lab', 1, 1),
(18, 'SGPT', 2, 3, '90.00', 'Lab', 1, 1),
(19, 'SGOT', 2, 3, '90.00', 'Lab', 1, 1),
(20, 'Phosphorus', 2, 3, '135.00', 'Lab', 1, 1),
(21, 'HbsAg', 2, 2, '165.00', 'Lab', 1, 1),
(22, 'Anti-HBs', 2, 1, '375.00', 'Lab', 1, 1),
(23, 'Anti-HCV', 2, 1, '405.00', 'Lab', 1, 1),
(24, 'Calcium (Ionized)/ Total', 2, 1, '135.00', 'Lab', 1, 1),
(25, 'Total Cholesterol', 2, 2, '110.00', 'Lab', 1, 1),
(26, 'HDL', 2, 4, '200.00', 'Lab', 1, 1),
(27, 'LDL', 2, 3, '200.00', 'Lab', 1, 1),
(28, 'Triglycerides', 2, 4, '110.00', 'Lab', 1, 1),
(29, 'Magnesium /Mg', 2, 6, '300.00', 'Lab', 1, 1),
(30, 'Sodium', 2, 3, '135.00', 'Lab', 1, 1),
(31, 'Chloride', 2, 6, '135.00', 'Lab', 1, 1),
(32, 'SGOT / AST', 2, 4, '90.00', 'Lab', 1, 1),
(33, 'SGPT / ALT', 2, 7, '90.00', 'Lab', 1, 1),
(34, 'Bilirubin(tb;b1;b2)', 2, 1, '95.00', 'Lab', 1, 1),
(35, 'GGT', 2, 0, '0.00', 'Lab', 1, 0),
(36, 'Alkaline Phosphatase / ALP', 2, 4, '90.00', 'Lab', 1, 1),
(37, 'Total Protein', 2, 2, '95.00', 'Lab', 1, 1),
(38, 'HbA1C /Glycosylated Hgb', 2, 2, '470.00', 'Lab', 1, 1),
(39, 'TPAG', 2, 2, '200.00', 'Lab', 1, 1),
(40, 'PSA', 2, 0, '0.00', 'Lab', 1, 0),
(41, 'Gram Stain', 2, 0, '0.00', 'Lab', 1, 0),
(42, 'AFB x3', 2, 5, '270.00', 'Lab', 1, 1),
(43, 'Lipid Profile', 2, 2, '300.00', 'Lab', 1, 1),
(44, 'Na;K;iCal', 2, 10, '0.00', 'Lab', 0, 1),
(45, 'ASO', 2, 2, '0.00', 'Lab', 0, 1),
(46, 'OGCT', 2, 4, '300.00', 'Lab', 0, 1),
(47, 'CBC w/ Plate Count', 2, 3, '120.00', 'Lab', 0, 1),
(48, 'Platelet count', 2, 2, '0.00', 'Lab', 0, 1),
(49, 'ABO w/ Rh typing', 2, 3, '95.00', 'Lab', 0, 1),
(50, 'ESR', 2, 2, '120.00', 'Lab', 0, 1),
(51, 'Bleeding Time', 2, 2, '105.00', 'Lab', 0, 1),
(52, 'Clotting Time', 2, 2, '105.00', 'Lab', 0, 1),
(53, 'APTT', 2, 2, '225.00', 'Lab', 0, 1),
(54, 'Prothrombin Time / PTPA', 2, 2, '340.00', 'Lab', 0, 1),
(55, 'Peripheral Blood Smear', 2, 3, '210.00', 'Lab', 0, 1),
(56, 'Routine Urinalysis', 2, 0, '0.00', 'Lab', 0, 0),
(57, 'Fecalysis', 2, 0, '0.00', 'Lab', 0, 0),
(58, 'Fecalysis w/ Occult Blood', 2, 0, '0.00', 'Lab', 0, 0),
(59, 'Pregnancy Test', 2, 3, '135.00', 'Lab', 0, 1),
(60, 'Iron', 2, 4, '300.00', 'Lab', 0, 1),
(61, 'Ferritin', 2, 5, '945.00', 'Lab', 0, 1),
(62, 'Anti-HAV (IgM)', 2, 0, '0.00', 'Lab', 0, 0),
(63, 'Anti-Hbe', 2, 0, '0.00', 'Lab', 0, 0),
(64, 'Anti- Hbc (Total)', 2, 0, '0.00', 'Lab', 0, 0),
(65, 'T3', 2, 4, '270.00', 'Lab', 1, 1),
(66, 'T4', 2, 3, '270.00', 'Lab', 0, 1),
(67, 'TSH', 2, 2, '450.00', 'Lab', 0, 1),
(68, 'FT3', 2, 1, '340.00', 'Lab', 0, 1),
(69, 'FT4', 2, 3, '340.00', 'Lab', 0, 1),
(70, 'Bicarbonate', 2, 0, '0.00', 'Lab', 0, 0),
(71, 'PTH', 2, 4, '2160.00', 'Lab', 0, 1),
(72, 'Tumor Marker', 2, 0, '0.00', 'Lab', 0, 0),
(73, 'TIBC', 2, 2, '450.00', 'Lab', 0, 1),
(74, 'Eprex', 3, 4, '950.00', 'Epoetin', 1, 1),
(75, 'Recormon', 3, 2, '1500.00', 'Epoetin', 1, 1),
(76, 'Renogen', 3, 2, '750.00', 'Epoetin', 1, 1),
(77, 'Eposino', 3, 6, '700.00', 'Epoetin', 1, 1),
(78, 'Hemapo', 3, 8, '800.00', 'Epoetin', 1, 1),
(79, 'NESP darbepoetin alfa', 3, 2, '1850.00', 'Epoetin', 1, 1),
(80, '0K (acid bath)', 4, 20, '300.00', 'Meds', 1, 1),
(81, '5% Dextrose', 4, 20, '200.00', 'Meds', 1, 1),
(82, 'Aborted TX', 4, 12, '500.00', 'Meds', 1, 1),
(83, 'Alcohol pads', 4, 49, '5.00', 'Supply', 1, 1),
(84, 'Ambulance 1', 4, 1, '1000.00', 'Ambulance', 0, 1),
(85, 'Ambulance 2', 4, 1, '2000.00', 'Ambulance', 0, 1),
(86, 'Amiodarone 150mg', 4, 12, '300.00', 'Meds', 1, 1),
(87, 'Antamine', 4, 14, '40.00', 'Meds', 1, 1),
(88, 'Asepto Syringe', 4, 10, '150.00', 'Meds', 1, 1),
(89, 'Aspirin 80mg', 4, 40, '5.00', 'Meds', 1, 1),
(90, 'Atropine Sulfate', 4, 30, '30.00', 'Meds', 1, 1),
(91, 'AV Fistula', 4, 22, '20.00', 'Meds', 1, 1),
(92, 'BCM Electrodes', 4, 5, '500.00', 'Supply', 1, 1),
(93, 'Benadryl 50mg cap', 4, 21, '40.00', 'Meds', 1, 1),
(94, 'Beta Pad', 4, 49, '5.00', 'Supply', 1, 1),
(95, 'Bloodline set', 4, 8, '200.00', 'Meds', 1, 1),
(96, 'Bricanyl tab', 4, 10, '20.00', 'Meds', 1, 1),
(97, 'BT charge', 4, 40, '100.00', 'Meds', 1, 1),
(98, 'BT Set', 4, 20, '50.00', 'Meds', 1, 1),
(99, 'BT Set+Benadryl', 4, 20, '90.00', 'Meds', 1, 1),
(100, 'Buscopan 10mg tab', 4, 21, '25.00', 'Meds', 1, 1),
(101, 'Buscopan amp', 4, 10, '135.00', 'Supply', 1, 1),
(102, 'Ca Gluconate 100mg/ml', 4, 4, '445.00', 'Meds', 1, 1),
(103, 'Calcium Gloconate', 4, 6, '445.00', 'Meds', 1, 1),
(104, 'Cath hep', 4, 15, '150.00', 'Meds', 1, 1),
(105, 'Clonipres 150mg', 4, 15, '55.00', 'Meds', 1, 1),
(106, 'Clonipres 75mg', 4, 18, '40.00', 'Meds', 1, 1),
(107, 'Combivent Nebule', 4, 15, '60.00', 'Meds', 1, 1),
(108, 'D5 NM', 4, 10, '200.00', 'Meds', 1, 1),
(109, 'Dextrose 50%/50ml', 4, 25, '80.00', 'Meds', 1, 1),
(110, 'Diazepam 10 Tab', 4, 25, '20.00', 'Meds', 1, 1),
(111, 'Diazepam 5 Tab', 4, 24, '15.00', 'Meds', 1, 1),
(112, 'Diazepam Amp', 4, 10, '300.00', 'Meds', 1, 1),
(113, 'Diphenhydramine', 4, 25, '180.00', 'Meds', 1, 1),
(114, 'Dobutamine', 4, 5, '700.00', 'Meds', 1, 1),
(115, 'Dolfenal Mefenamic', 4, 40, '40.00', 'Meds', 1, 1),
(116, 'Dopamine amp', 4, 10, '250.00', 'Meds', 1, 1),
(117, 'Dormicum/Midazolam', 4, 15, '130.00', 'Meds', 1, 1),
(118, 'ECG', 4, 8, '300.00', 'Meds', 1, 1),
(119, 'Epinephrine', 4, 22, '60.00', 'Meds', 1, 1),
(120, 'ET Tube', 4, 9, '250.00', 'Meds', 1, 1),
(121, 'Extra Heparin', 4, 40, '50.00', 'Meds', 1, 1),
(122, 'Extra TX', 4, 4, '500.00', 'Meds', 1, 1),
(123, 'Extra TX HMO', 4, 4, '800.00', 'Meds', 1, 1),
(124, 'Face Mask', 4, 40, '5.00', 'Supply', 1, 1),
(125, 'Ferrofer', 4, 5, '500.00', 'Meds', 1, 1),
(126, 'Fistula Kit', 4, 10, '75.00', 'Meds', 1, 1),
(127, 'Fucidin ointment', 4, 10, '400.00', 'Meds', 1, 1),
(128, 'Furosemide/Lasix', 4, 15, '85.00', 'Meds', 1, 1),
(129, 'G 7.0 ET Tube', 4, 5, '250.00', 'Meds', 1, 1),
(130, 'G 7.5 ET Tube', 4, 5, '250.00', 'Meds', 1, 1),
(131, 'G 8.0 ET Tube', 4, 5, '250.00', 'Supply', 1, 1),
(132, 'G16 catheter', 4, 5, '85.00', 'Meds', 1, 1),
(133, 'G20 catheter', 4, 10, '85.00', 'Meds', 1, 1),
(134, 'G22 catheter', 4, 4, '85.00', 'Meds', 1, 1),
(135, 'G24 catheter', 4, 5, '85.00', 'Meds', 1, 1),
(136, 'gauze 2x2', 4, 40, '5.00', 'Supply', 1, 1),
(137, 'gauze 4x4', 4, 50, '5.00', 'Supply', 1, 1),
(138, 'Gentamicin 80mg/2ml', 4, 20, '85.00', 'Meds', 1, 1),
(139, 'Gloves', 4, 40, '5.00', 'Supply', 1, 1),
(140, 'Hemostan', 4, 30, '35.00', 'Meds', 1, 1),
(141, 'Hemostan Amp', 4, 5, '300.00', 'Meds', 1, 1),
(142, 'Heparin vial', 4, 9, '250.00', 'Supply', 1, 1),
(143, 'Heplock', 4, 5, '60.00', 'Meds', 1, 1),
(144, 'HGT Strips', 4, 20, '75.00', 'Supply', 1, 1),
(145, 'Hydrocort 100mg', 4, 10, '100.00', 'Meds', 1, 1),
(146, 'Hydrocort 250mg', 4, 8, '180.00', 'Meds', 1, 1),
(147, 'IJ Flushing', 4, 10, '150.00', 'Meds', 1, 1),
(148, 'Immodium 2mg cap', 4, 20, '25.00', 'Meds', 1, 1),
(149, 'Inohep 2ml vial', 4, 4, '1500.00', 'Supply', 1, 1),
(150, 'Isordil 10mg Tab', 4, 30, '20.00', 'Meds', 1, 1),
(151, 'Isordil 5mg Sub', 4, 25, '25.00', 'Meds', 1, 1),
(152, 'IV Cath G20,22', 4, 5, '85.00', 'Meds', 1, 1),
(153, 'IV Fe Charge', 4, 10, '100.00', 'Meds', 1, 1),
(154, 'Kalimate 5g', 4, 8, '100.00', 'Meds', 1, 1),
(155, 'Ketobest 600mg', 4, 30, '30.00', 'Meds', 1, 1),
(156, 'Lanoxin amp', 4, 8, '220.00', 'Meds', 1, 1),
(157, 'Lanoxin Tab', 4, 30, '15.00', 'Meds', 1, 1),
(158, 'Lidocaine /cc', 4, 40, '10.00', 'Meds', 1, 1),
(159, 'Macroset', 4, 5, '130.00', 'Meds', 1, 1),
(160, 'Mannitol', 4, 5, '175.00', 'Meds', 1, 1),
(161, 'Mefenamic Acid 500mg', 4, 60, '15.00', 'Meds', 1, 1),
(162, 'Micropore', 4, 40, '45.00', 'Meds', 1, 1),
(163, 'Microset', 4, 15, '130.00', 'Meds', 1, 1),
(164, 'misc fee', 4, 1, '75.00', 'Fee', 0, 1),
(165, 'Na Bicarb (8.4%) 10ml', 4, 14, '75.00', 'Meds', 1, 1),
(166, 'Na Bicarb (8.4%) 50ml', 4, 8, '150.00', 'Meds', 1, 1),
(167, 'NaCl (9%) 50ml', 4, 20, '70.00', 'Meds', 1, 1),
(168, 'Neb Kit', 4, 10, '80.00', 'Meds', 1, 1),
(169, 'NGT Tube', 4, 8, '200.00', 'Supply', 1, 1),
(170, 'Nicardipine amp', 4, 20, '250.00', 'Meds', 1, 1),
(171, 'Nifedipine 5mg', 4, 25, '25.00', 'Meds', 1, 1),
(172, 'Nitroglycerin Patch', 4, 5, '100.00', 'Supply', 1, 1),
(173, 'NSS (0.9 %)', 4, 8, '75.00', 'Meds', 1, 1),
(174, 'O2 Cannula', 4, 10, '35.00', 'Meds', 1, 1),
(175, 'O2 Inhalation /30min', 4, 15, '40.00', 'Meds', 1, 1),
(176, 'O2 Mask', 4, 15, '110.00', 'Supply', 1, 1),
(177, 'OR Fee', 4, 1, '500.00', 'Fee', 0, 1),
(178, 'Paracetamol amp', 4, 20, '70.00', 'Meds', 1, 1),
(179, 'Paracetamol Tab', 4, 38, '10.00', 'Meds', 1, 1),
(180, 'Plasil Amp', 4, 20, '60.00', 'Supply', 1, 1),
(181, 'Plasil Tab', 4, 15, '15.00', 'Meds', 1, 1),
(182, 'Ponstant Mefenamic', 4, 8, '45.00', 'Meds', 1, 1),
(183, 'Potassium Chloride 20ml', 4, 12, '70.00', 'Meds', 1, 1),
(184, 'Ranitidine Amp', 4, 5, '130.00', 'Meds', 1, 1),
(185, 'Ranitidine Tab', 4, 20, '25.00', 'Meds', 1, 1),
(186, 'Renvela', 4, 8, '62.00', 'Meds', 1, 1),
(187, 'Retic Count', 4, 1, '110.00', 'Service', 0, 1),
(188, 'Ribotril', 4, 20, '20.00', 'Meds', 1, 1),
(189, 'Sodium Chloride', 4, 12, '150.00', 'Supply', 1, 1),
(190, 'Solu Set', 4, 4, '250.00', 'Supply', 1, 1),
(191, 'Suction Catheter', 4, 20, '20.00', 'Supply', 1, 1),
(192, 'Suction Tip G16', 4, 10, '100.00', 'Supply', 1, 1),
(193, 'Suture', 4, 4, '250.00', 'Supply', 1, 1),
(194, 'Syringe 10cc', 4, 40, '10.00', 'Supply', 1, 1),
(195, 'Syringe 1cc', 4, 91, '5.00', 'Supply', 1, 1),
(196, 'Syringe 20cc', 4, 40, '15.00', 'Supply', 1, 1),
(197, 'Syringe 3cc', 4, 80, '5.00', 'Supply', 1, 1),
(198, 'Tram cetra', 4, 8, '65.00', 'Meds', 1, 1),
(199, 'Tram dolcet', 4, 10, '65.00', 'Meds', 1, 1),
(200, 'Tramadol amp', 4, 4, '100.00', 'Meds', 1, 1),
(201, 'Underpads', 4, 50, '5.00', 'Supply', 1, 1),
(202, 'vaccine(FLU)', 4, 10, '650.00', 'Supply', 1, 1),
(203, 'vaccine(pneumo)', 4, 10, '1100.00', 'Supply', 1, 1),
(204, 'Wound dressing', 4, 20, '200.00', 'Supply', 1, 1),
(205, 'Tegaderm', 4, 10, '100.00', 'Supply', 1, 1),
(206, 'Nephrisol D', 4, 10, '430.00', 'Meds', 1, 1),
(207, 'H & H strip', 4, 10, '100.00', 'Supply', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_patient`
--

CREATE TABLE IF NOT EXISTS `tbl_patient` (
  `patient_id` int(11) NOT NULL AUTO_INCREMENT,
  `lastname` varchar(100) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `gender_id` tinyint(4) NOT NULL,
  `birthday` date NOT NULL,
  `civil_status_id` int(11) NOT NULL,
  `religion` varchar(100) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `contact` varchar(100) NOT NULL,
  `address` varchar(255) NOT NULL,
  `clinic_abstract` tinyint(1) NOT NULL,
  `hemoglobin_order` tinyint(1) NOT NULL,
  `latest_lab` tinyint(1) NOT NULL,
  `latest_chest_xray` tinyint(1) NOT NULL,
  `hepatitis_profile` tinyint(1) NOT NULL,
  `dialysis_logsheet` tinyint(1) NOT NULL,
  `storage_code` varchar(100) NOT NULL,
  `is_complete` tinyint(1) NOT NULL,
  `is_dead` tinyint(1) NOT NULL,
  PRIMARY KEY (`patient_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=23 ;

--
-- Dumping data for table `tbl_patient`
--

INSERT INTO `tbl_patient` (`patient_id`, `lastname`, `firstname`, `gender_id`, `birthday`, `civil_status_id`, `religion`, `phone`, `contact`, `address`, `clinic_abstract`, `hemoglobin_order`, `latest_lab`, `latest_chest_xray`, `hepatitis_profile`, `dialysis_logsheet`, `storage_code`, `is_complete`, `is_dead`) VALUES
(1, 'Romeo', 'Terrence', 1, '1992-03-16', 2, 'Catholic', '0990121212', '9812121', 'Brgy Address Brgy Street Address City', 1, 1, 1, 1, 1, 1, 'ABCD-123', 1, 0),
(2, 'Fajardo', 'June Mar', 1, '1989-11-17', 2, 'Catholic', '0909121212', '9013231', 'Brgy Address Street City City City Manila', 1, 1, 1, 1, 1, 1, 'ABCD-123', 1, 0),
(3, 'Poe', 'Fernando', 1, '1949-03-24', 2, 'Catholic', '0929121212', '9211212', 'St. Address Street Corner XYZ Street Manila', 0, 0, 0, 0, 0, 0, '', 0, 1),
(4, 'Aranda', 'Alicia', 2, '1961-07-20', 2, 'Catholic', '09069012345', '9123456', 'asdasdasds street ABCD Brgy Quezon City', 0, 0, 0, 0, 0, 0, '', 0, 0),
(5, 'Alcantara', 'Rogelio', 1, '1945-07-12', 2, 'Catholic', '090909009090', '99090909', 'adasdsdasd aasdasdad asdsd AADS', 0, 0, 0, 0, 0, 0, '', 0, 0),
(6, 'Alvarez', 'Mary Ann', 2, '1974-06-12', 2, 'Catholic', '099090909090', '990909090', 'asdsadasd asd asda sad asd asd asdasasda ', 0, 0, 0, 0, 0, 0, '', 0, 0),
(7, 'Atanacio', 'John Mori', 1, '1985-07-18', 1, 'Catholic', '99090909099', '90909990', 'sasdfsdfasfhfgsfgfhsfa asfgdasd dfgsaf asd sa ', 0, 0, 0, 0, 0, 0, '', 0, 0),
(8, 'Basco', 'Josefina', 2, '1960-08-19', 3, 'INC', '0909090909089', '990192121', 'asdasd asd asda sdasdasdasasdss ssa ', 1, 1, 1, 1, 1, 1, 'STORANGY', 1, 0),
(9, 'Cabana', 'Melba', 2, '1960-08-19', 2, 'Catholic', '09990909091', '99121212', 'asdad asd asda s', 0, 0, 0, 0, 0, 0, '', 0, 0),
(10, 'De Leon', 'Maria Alma', 2, '1966-05-09', 2, 'Catholic', '99898989898', '093992', 'asdasd asdasd asdadasd asdas aasa ssa sas', 0, 0, 0, 0, 0, 0, '', 0, 0),
(11, 'Francisco', 'Loveleo', 1, '1975-02-19', 2, 'Catholic', '099090901212', '99090121', 'sdasda asd fhdfg sfyn hfd sdf hsadf asdad sad asd ', 0, 0, 0, 0, 0, 0, '', 0, 0),
(12, 'Llovit', 'Paul Jomar', 1, '1982-07-23', 1, 'Catholic', '09909091213424', '992121212', 'as ad asd asd asd asd asda sdas dasda sda dasd ad asd asd a', 0, 0, 0, 0, 0, 0, '', 0, 0),
(13, 'Masakayan', 'Renowne', 1, '1975-10-24', 2, 'Catholic', '0912121423132', '990992121', ' sdfa afa adasda sadad as asda sda dad aadad as asd as as a ssa', 0, 0, 0, 0, 0, 0, '', 0, 0),
(14, 'Partoza', 'Carlito', 1, '1979-07-12', 1, 'Catholic', '099912121223', '99121211', 'fsdgfsdg dsf d hfmhjfghb vxcxsdh t dgdfg dgfg ssfssdfgdfg dfg sdfg sdg sdfgdsfg s', 0, 0, 0, 0, 0, 0, '', 0, 0),
(15, 'Reyes', 'Emelina', 2, '1955-06-16', 4, 'Catholic', '0991212121212', '991212121', 'fs df sdf a asd asf d fadadfa sfa asd adaddgsdgasdasgasd', 1, 1, 1, 1, 1, 1, 'PASS-813', 1, 0),
(16, 'Santos', 'Epifanio', 1, '1954-08-11', 3, 'Catholic', '0909012121', '0992121', '3sf dsfs a q3 sdf sdf sfa sasa sd', 0, 0, 0, 0, 0, 0, '', 0, 0),
(17, 'Siñel', 'Ryan', 1, '1984-10-15', 2, 'Born Again', '99121212', '9231313', 'dfdsf gsdfshjfgdfgfdhfjgdgsdfsdf', 0, 0, 0, 0, 0, 0, '', 0, 0),
(18, 'Valdez', 'Eric', 1, '1975-08-20', 2, 'Catholic', '099912121211', '99912121', 'gh dfds sdf 452452fdt345 43 dfsf sd fw4r wsfg fg 3gsdfgsfdg sdfg sdf ge5t sfdg sets df ', 1, 1, 1, 1, 1, 1, 'STORANGY', 1, 0),
(19, 'Yumul', 'Romulo', 1, '1953-02-14', 4, 'Muslim', '09991212546355', '0923213123', ' fgs d3qq34dfs df3w tfdsf4r3453wsf frt ert sd esrt 34 tsddf sefgs', 1, 1, 1, 1, 1, 1, 'STORANGY', 1, 0),
(20, 'Formales', 'Lydeson', 1, '1989-07-15', 1, 'Born Again', '099121121434234', '934234234', 'asdasd asd asda sas 23 srg dg 35 sdg sfgs5 sdfg fdsg 5s ', 1, 1, 1, 1, 1, 1, 'SCARRA', 1, 0),
(21, 'Gratuito', 'Fe', 2, '1959-04-20', 3, 'Catholic', '09121212133', '12312313', '453453524 fs dfwr2 sddf sdfsdsdf ', 1, 1, 1, 1, 1, 1, 'STORANGY', 1, 0),
(22, 'Hernandez', 'Joel', 1, '1994-07-21', 1, 'Catholic', '090231331323', '992131231', 'dsfs fsd wr2 3 sd fgsd gxgsdr 34 tdfg sfg 3srf sa ', 0, 0, 0, 0, 0, 0, '', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_payment`
--

CREATE TABLE IF NOT EXISTS `tbl_payment` (
  `payment_id` int(11) NOT NULL AUTO_INCREMENT,
  `payment_method` varchar(50) NOT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

--
-- Dumping data for table `tbl_payment`
--

INSERT INTO `tbl_payment` (`payment_id`, `payment_method`) VALUES
(1, 'cash'),
(2, 'check'),
(3, 'credit Card'),
(4, 'phic'),
(5, 'pcso'),
(6, 'maxicare'),
(7, 'lacson'),
(8, 'asianlife'),
(9, 'medocare'),
(10, 'valucare'),
(11, 'flexicare'),
(12, 'dswd'),
(13, 'A/R'),
(14, 'hppi');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sales`
--

CREATE TABLE IF NOT EXISTS `tbl_sales` (
  `sales_id` int(11) NOT NULL AUTO_INCREMENT,
  `schedule_id` int(11) NOT NULL,
  `inventory_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `subtotal` int(11) NOT NULL,
  `payment_id` int(11) NOT NULL,
  `datecommit` date NOT NULL,
  PRIMARY KEY (`sales_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=18 ;

--
-- Dumping data for table `tbl_sales`
--

INSERT INTO `tbl_sales` (`sales_id`, `schedule_id`, `inventory_id`, `quantity`, `subtotal`, `payment_id`, `datecommit`) VALUES
(1, 5, 2, 1, 3320, 5, '2018-10-12'),
(2, 5, 195, 1, 5, 5, '2018-10-12'),
(3, 5, 179, 2, 20, 5, '2018-10-12'),
(4, 4, 1, 1, 1850, 5, '2018-10-12'),
(5, 4, 195, 1, 5, 5, '2018-10-12'),
(6, 4, 83, 1, 5, 5, '2018-10-12'),
(7, 3, 3, 1, 1850, 1, '2018-10-12'),
(8, 3, 195, 1, 5, 1, '2018-10-12'),
(9, 3, 83, 1, 5, 1, '2018-10-12'),
(15, 7, 3, 1, 1850, 1, '2018-10-12'),
(16, 7, 179, 1, 10, 1, '2018-10-12'),
(17, 7, 195, 1, 5, 1, '2018-10-12');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_schedule`
--

CREATE TABLE IF NOT EXISTS `tbl_schedule` (
  `schedule_id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) NOT NULL,
  `scheduled_date` date NOT NULL,
  `scheduled_time` varchar(50) NOT NULL,
  `is_attended` tinyint(1) NOT NULL,
  `is_paid` tinyint(1) NOT NULL,
  PRIMARY KEY (`schedule_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `tbl_schedule`
--

INSERT INTO `tbl_schedule` (`schedule_id`, `patient_id`, `scheduled_date`, `scheduled_time`, `is_attended`, `is_paid`) VALUES
(1, 1, '2018-10-10', '8am - 12pm', 0, 0),
(2, 2, '2018-10-09', '8am - 12pm', 0, 0),
(3, 20, '2018-10-10', '8am - 12pm', 1, 1),
(4, 20, '2018-10-09', '1pm - 5pm', 1, 1),
(5, 15, '2018-10-12', '8am - 12pm', 1, 1),
(6, 21, '2018-10-13', '8am - 12pm', 1, 0),
(7, 18, '2018-10-13', '1pm - 5pm', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_summary`
--

CREATE TABLE IF NOT EXISTS `tbl_summary` (
  `summary_id` int(11) NOT NULL AUTO_INCREMENT,
  `schedule_id` int(11) NOT NULL,
  `inventory_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`summary_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE IF NOT EXISTS `tbl_user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `usertype_id` int(11) NOT NULL COMMENT '1=admin; 2=cashier;',
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `lastname` varchar(100) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`user_id`, `usertype_id`, `username`, `password`, `lastname`, `firstname`) VALUES
(1, 1, 'admin1', '5f4dcc3b5aa765d61d8327deb882cf99', 'Mo', 'Lolo'),
(2, 2, 'Cashier1', '5f4dcc3b5aa765d61d8327deb882cf99', 'Mo', 'Nanay'),
(3, 2, 'Cashier2', '5f4dcc3b5aa765d61d8327deb882cf99', 'Mo', 'Tatay'),
(4, 2, 'Cashier3', 'md5(password)', 'Mo', 'Mukha');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_usertype`
--

CREATE TABLE IF NOT EXISTS `tbl_usertype` (
  `usertype_id` int(11) NOT NULL AUTO_INCREMENT,
  `usertype` varchar(10) NOT NULL,
  PRIMARY KEY (`usertype_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `tbl_usertype`
--

INSERT INTO `tbl_usertype` (`usertype_id`, `usertype`) VALUES
(1, 'admin'),
(2, 'cashier');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
