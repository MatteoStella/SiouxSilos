-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 192.168.56.2
-- Creato il: Mag 20, 2021 alle 15:42
-- Versione del server: 10.3.28-MariaDB-1:10.3.28+maria~focal
-- Versione PHP: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `siouxsilos`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `alarm_setting`
--

CREATE TABLE `alarm_setting` (
  `Id` int(11) NOT NULL,
  `id_silos` int(11) NOT NULL,
  `temperature` int(11) NOT NULL,
  `humidity` int(11) NOT NULL,
  `pressure` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Dump dei dati per la tabella `alarm_setting`
--

INSERT INTO `alarm_setting` (`Id`, `id_silos`, `temperature`, `humidity`, `pressure`) VALUES
(2, 1, 10, 10, 10),
(3, 2, 10, 10, 10),
(4, 3, 10, 10, 10),
(5, 4, 10, 10, 10),
(6, 5, 10, 10, 10),
(7, 6, 10, 10, 10),
(8, 7, 10, 10, 10);

-- --------------------------------------------------------

--
-- Struttura della tabella `alarm_thresholds`
--

CREATE TABLE `alarm_thresholds` (
  `id_alarm_thresholds` int(11) NOT NULL,
  `Id_Silos` int(11) NOT NULL,
  `level` int(2) NOT NULL,
  `humidity` double(10,2) NOT NULL,
  `temperature` double(10,2) NOT NULL,
  `pressure` double(10,2) NOT NULL,
  `description` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Struttura della tabella `allarm`
--

CREATE TABLE `allarm` (
  `id_allarm` int(11) NOT NULL,
  `type` char(20) DEFAULT NULL,
  `description` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Struttura della tabella `allarm_history`
--

CREATE TABLE `allarm_history` (
  `id_allarm_history` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  `id_allarm` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Struttura della tabella `measurements`
--

CREATE TABLE `measurements` (
  `id_measurements` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `level` int(2) NOT NULL,
  `humidity` double(10,2) NOT NULL,
  `pressure` double(10,2) NOT NULL,
  `temperature` double(10,2) NOT NULL,
  `id_silos` int(11) DEFAULT NULL,
  `control` tinyint(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `measurements`
--

INSERT INTO `measurements` (`id_measurements`, `data`, `level`, `humidity`, `pressure`, `temperature`, `id_silos`, `control`) VALUES
(2753, '2021-05-20 17:42:49', 6, 81.00, 99.00, 15.00, 1, 0),
(2754, '2021-05-20 17:42:49', 6, 80.00, 105.00, 15.00, 2, 0),
(2755, '2021-05-20 17:42:49', 5, 87.00, 102.00, 15.00, 3, 0),
(2756, '2021-05-20 17:42:49', 1, 78.00, 105.00, 15.00, 4, 0),
(2757, '2021-05-20 17:42:49', 1, 81.00, 93.00, 15.00, 5, 0),
(2758, '2021-05-20 17:42:49', 5, 87.00, 102.00, 15.00, 6, 0),
(2759, '2021-05-20 17:42:49', 3, 83.00, 106.00, 15.00, 7, 0);

-- --------------------------------------------------------

--
-- Struttura della tabella `permissions`
--

CREATE TABLE `permissions` (
  `id_permission` int(1) NOT NULL,
  `description` char(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `permissions`
--

INSERT INTO `permissions` (`id_permission`, `description`) VALUES
(9, 'Full control');

-- --------------------------------------------------------

--
-- Struttura della tabella `sensor`
--

CREATE TABLE `sensor` (
  `id_sensor` int(5) NOT NULL,
  `description` char(20) NOT NULL,
  `id_silos` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `sensor`
--

INSERT INTO `sensor` (`id_sensor`, `description`, `id_silos`) VALUES
(1, 'Level1', 1),
(2, 'Level2', 1),
(3, 'Level3', 1),
(4, 'Level4', 1),
(5, 'Level5', 1),
(6, 'Level6', 1),
(7, 'Level7', 1),
(8, 'Level8', 1),
(9, 'Temperature', 1),
(10, 'Pressure', 1),
(11, 'Humidity', 1),
(12, 'Level1', 2),
(13, 'Level2', 2),
(14, 'Level3', 2),
(15, 'Level4', 2),
(16, 'Level5', 2),
(17, 'Level6', 2),
(18, 'Level7', 2),
(19, 'Level8', 2),
(20, 'Temperature', 2),
(21, 'Pressure', 2),
(22, 'Humidity', 2),
(23, 'Level1', 3),
(24, 'Level2', 3),
(25, 'Level3', 3),
(26, 'Level4', 3),
(27, 'Level5', 3),
(28, 'Level6', 3),
(29, 'Level7', 3),
(30, 'Level8', 3),
(31, 'Temperature', 3),
(32, 'Pressure', 3),
(33, 'Humidity', 3),
(34, 'Level1', 4),
(35, 'Level2', 4),
(36, 'Level3', 4),
(37, 'Level4', 4),
(38, 'Level5', 4),
(39, 'Level6', 4),
(40, 'Level7', 4),
(41, 'Level8', 4),
(42, 'Temperature', 4),
(43, 'Pressure', 4),
(44, 'Humidity', 4),
(45, 'Level1', 5),
(46, 'Level2', 5),
(47, 'Level3', 5),
(48, 'Level4', 5),
(49, 'Level5', 5),
(50, 'Level6', 5),
(51, 'Level7', 5),
(52, 'Level8', 5),
(53, 'Temperature', 5),
(54, 'Pressure', 5),
(55, 'Humidity', 5),
(56, 'Level1', 6),
(57, 'Level2', 6),
(58, 'Level3', 6),
(59, 'Level4', 6),
(60, 'Level5', 6),
(61, 'Level6', 6),
(62, 'Level7', 6),
(63, 'Level8', 6),
(64, 'Temperature', 6),
(65, 'Pressure', 6),
(66, 'Humidity', 6),
(67, 'Level1', 7),
(68, 'Level2', 7),
(69, 'Level3', 7),
(70, 'Level4', 7),
(71, 'Level5', 7),
(72, 'Level6', 7),
(73, 'Level7', 7),
(74, 'Level8', 7),
(75, 'Temperature', 7),
(76, 'Pressure', 7),
(77, 'Humidity', 7);

-- --------------------------------------------------------

--
-- Struttura della tabella `silos`
--

CREATE TABLE `silos` (
  `id_silos` int(11) NOT NULL,
  `name_silos` char(20) NOT NULL,
  `content` char(15) NOT NULL,
  `id_zone` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `silos`
--

INSERT INTO `silos` (`id_silos`, `name_silos`, `content`, `id_zone`) VALUES
(1, 'Silos1', 'Acqua', 1),
(2, 'Silos2', 'Acqua', 1),
(3, 'Silos3', 'Acqua', 1),
(4, 'Silos4', 'Acqua', 1),
(5, 'Silos5', 'Acqua', 2),
(6, 'Silos6', 'Acqua', 2),
(7, 'Silos7', 'Acqua', 2);

-- --------------------------------------------------------

--
-- Struttura della tabella `users`
--

CREATE TABLE `users` (
  `id_user` char(20) NOT NULL,
  `psw` char(20) NOT NULL,
  `permission` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `users`
--

INSERT INTO `users` (`id_user`, `psw`, `permission`) VALUES
('Administrator', 'Vmware1!', 9);

-- --------------------------------------------------------

--
-- Struttura della tabella `warning_setting`
--

CREATE TABLE `warning_setting` (
  `Id` int(11) NOT NULL,
  `id_silos` int(11) NOT NULL,
  `temperature` int(11) NOT NULL,
  `humidity` int(11) NOT NULL,
  `pressure` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Dump dei dati per la tabella `warning_setting`
--

INSERT INTO `warning_setting` (`Id`, `id_silos`, `temperature`, `humidity`, `pressure`) VALUES
(5, 1, 5, 5, 5),
(6, 2, 5, 5, 5),
(7, 3, 5, 5, 5),
(8, 4, 5, 5, 5),
(9, 5, 5, 5, 5),
(10, 6, 5, 5, 5),
(11, 7, 5, 5, 5);

-- --------------------------------------------------------

--
-- Struttura della tabella `zone`
--

CREATE TABLE `zone` (
  `id_zone` int(2) NOT NULL,
  `name_zone` char(15) DEFAULT NULL,
  `desciption` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `zone`
--

INSERT INTO `zone` (`id_zone`, `name_zone`, `desciption`) VALUES
(1, 'Zona 1', NULL),
(2, 'Zona 2', NULL);

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `alarm_setting`
--
ALTER TABLE `alarm_setting`
  ADD PRIMARY KEY (`Id`);

--
-- Indici per le tabelle `alarm_thresholds`
--
ALTER TABLE `alarm_thresholds`
  ADD PRIMARY KEY (`id_alarm_thresholds`);

--
-- Indici per le tabelle `allarm`
--
ALTER TABLE `allarm`
  ADD PRIMARY KEY (`id_allarm`);

--
-- Indici per le tabelle `allarm_history`
--
ALTER TABLE `allarm_history`
  ADD PRIMARY KEY (`id_allarm_history`),
  ADD KEY `id_allarm` (`id_allarm`);

--
-- Indici per le tabelle `measurements`
--
ALTER TABLE `measurements`
  ADD PRIMARY KEY (`id_measurements`),
  ADD KEY `id_silos` (`id_silos`);

--
-- Indici per le tabelle `permissions`
--
ALTER TABLE `permissions`
  ADD PRIMARY KEY (`id_permission`);

--
-- Indici per le tabelle `sensor`
--
ALTER TABLE `sensor`
  ADD PRIMARY KEY (`id_sensor`),
  ADD KEY `id_silos` (`id_silos`);

--
-- Indici per le tabelle `silos`
--
ALTER TABLE `silos`
  ADD PRIMARY KEY (`id_silos`),
  ADD KEY `id_zone` (`id_zone`);

--
-- Indici per le tabelle `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id_user`),
  ADD KEY `permission` (`permission`);

--
-- Indici per le tabelle `warning_setting`
--
ALTER TABLE `warning_setting`
  ADD PRIMARY KEY (`Id`);

--
-- Indici per le tabelle `zone`
--
ALTER TABLE `zone`
  ADD PRIMARY KEY (`id_zone`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `alarm_setting`
--
ALTER TABLE `alarm_setting`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT per la tabella `alarm_thresholds`
--
ALTER TABLE `alarm_thresholds`
  MODIFY `id_alarm_thresholds` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=80;

--
-- AUTO_INCREMENT per la tabella `allarm`
--
ALTER TABLE `allarm`
  MODIFY `id_allarm` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `allarm_history`
--
ALTER TABLE `allarm_history`
  MODIFY `id_allarm_history` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `measurements`
--
ALTER TABLE `measurements`
  MODIFY `id_measurements` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2760;

--
-- AUTO_INCREMENT per la tabella `warning_setting`
--
ALTER TABLE `warning_setting`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `allarm_history`
--
ALTER TABLE `allarm_history`
  ADD CONSTRAINT `allarm_history_ibfk_1` FOREIGN KEY (`id_allarm`) REFERENCES `allarm` (`id_allarm`);

--
-- Limiti per la tabella `measurements`
--
ALTER TABLE `measurements`
  ADD CONSTRAINT `measurements_ibfk_1` FOREIGN KEY (`id_silos`) REFERENCES `silos` (`id_silos`);

--
-- Limiti per la tabella `sensor`
--
ALTER TABLE `sensor`
  ADD CONSTRAINT `sensor_ibfk_1` FOREIGN KEY (`id_silos`) REFERENCES `silos` (`id_silos`),
  ADD CONSTRAINT `sensor_ibfk_2` FOREIGN KEY (`id_silos`) REFERENCES `silos` (`id_silos`);

--
-- Limiti per la tabella `silos`
--
ALTER TABLE `silos`
  ADD CONSTRAINT `silos_ibfk_1` FOREIGN KEY (`id_zone`) REFERENCES `zone` (`id_zone`);

--
-- Limiti per la tabella `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`permission`) REFERENCES `permissions` (`id_permission`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
