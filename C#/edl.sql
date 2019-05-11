-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  lun. 06 mai 2019 à 12:51
-- Version du serveur :  5.7.24
-- Version de PHP :  7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `edl`
--

-- --------------------------------------------------------

--
-- Structure de la table `capteurs`
--

DROP TABLE IF EXISTS `capteurs`;
CREATE TABLE IF NOT EXISTS `capteurs` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(30) NOT NULL,
  `Adresse_IP` varchar(15) NOT NULL,
  `Type` varchar(15) NOT NULL,
  `Grandeur` varchar(10) NOT NULL,
  `Calibre_Max` int(3) NOT NULL,
  `A` float NOT NULL,
  `B` float NOT NULL,
  `Nom_Config` varchar(20) NOT NULL,
  `Model` varchar(15) NOT NULL,
  `Marque` varchar(15) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `capteurs`
--

INSERT INTO `capteurs` (`ID`, `Nom`, `Adresse_IP`, `Type`, `Grandeur`, `Calibre_Max`, `A`, `B`, `Nom_Config`, `Model`, `Marque`) VALUES
(1, 'Pince Orange', '', 'Intensite', 'Alternatif', 30, 10, 4, 'INT_ALT_A:30_B:4.2', 'XP-12', 'W&W'),
(20, 'eazeza', '', 'Intensite', 'Alternatif', 1, 12, 12, 'test', 'eaz', 'zeaze'),
(19, 'azeaz', '', 'Thermique', 'Alternatif', 1, 1454, 54, 'test', 'eqsdqsd', 'azeza'),
(18, 'aq', '', 'Thermique', 'Alternatif', 1, 10, 10, 'test', 'zae', 'qs'),
(17, 'azeaze', '', 'Intensite', 'Alternatif', 1, 101, 2, 'test', 'eaze', 'aze'),
(13, 'Phil', '', 'Intensite', 'Alternatif', 10, 1, 2, 'Config', 'XP-13', 'Y&W');

-- --------------------------------------------------------

--
-- Structure de la table `config_enregistrement`
--

DROP TABLE IF EXISTS `config_enregistrement`;
CREATE TABLE IF NOT EXISTS `config_enregistrement` (
  `ID` int(5) NOT NULL AUTO_INCREMENT,
  `Ligne` int(5) NOT NULL,
  `ID_Capteur` int(11) NOT NULL,
  `Ligne_Mesurer` varchar(255) NOT NULL,
  `Utilisisation` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `config_enregistrement`
--

INSERT INTO `config_enregistrement` (`ID`, `Ligne`, `ID_Capteur`, `Ligne_Mesurer`, `Utilisisation`) VALUES
(1, 2, 1, 'Prise_cuisine', 0);

-- --------------------------------------------------------

--
-- Structure de la table `membres`
--

DROP TABLE IF EXISTS `membres`;
CREATE TABLE IF NOT EXISTS `membres` (
  `ID` tinyint(5) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(25) NOT NULL,
  `Prenom` varchar(25) NOT NULL,
  `Pseudo` varchar(50) NOT NULL,
  `MDP` varchar(25) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `membres`
--

INSERT INTO `membres` (`ID`, `Nom`, `Prenom`, `Pseudo`, `MDP`) VALUES
(1, 'Michelle', 'Jean', 'zeleph', '123456');

-- --------------------------------------------------------

--
-- Structure de la table `mesures_conso`
--

DROP TABLE IF EXISTS `mesures_conso`;
CREATE TABLE IF NOT EXISTS `mesures_conso` (
  `ID` int(5) NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  `Heure` time NOT NULL,
  `Intensite` float NOT NULL,
  `Puissance` float NOT NULL,
  `Energie_KWh` float NOT NULL,
  `Ligne_Mesure` varchar(30) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `mesures_conso`
--

INSERT INTO `mesures_conso` (`ID`, `Date`, `Heure`, `Intensite`, `Puissance`, `Energie_KWh`, `Ligne_Mesure`) VALUES
(1, '2019-02-28', '10:00:00', 10, 15, 15000, 'prise salon'),
(2, '2019-02-28', '11:00:00', 8, 230, 1500, 'prise chambre 1'),
(3, '2019-02-28', '12:00:00', 5, 500, 2350, 'Prise Salon'),
(4, '2019-02-28', '13:00:00', 8, 230, 1500, 'prise chambre 1'),
(5, '2019-02-28', '14:00:00', 5, 500, 2350, 'Prise Salon');

-- --------------------------------------------------------

--
-- Structure de la table `mesures_production`
--

DROP TABLE IF EXISTS `mesures_production`;
CREATE TABLE IF NOT EXISTS `mesures_production` (
  `ID` int(5) NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  `Heure` time NOT NULL,
  `Intensite` int(5) NOT NULL,
  `Puissance` int(5) NOT NULL,
  `Energie_KWh` int(10) NOT NULL,
  `Lumiere` int(3) NOT NULL,
  `Humidite` int(3) NOT NULL,
  `Temperature` int(3) NOT NULL,
  `Ligne_Mesure` varchar(30) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `mesures_production`
--

INSERT INTO `mesures_production` (`ID`, `Date`, `Heure`, `Intensite`, `Puissance`, `Energie_KWh`, `Lumiere`, `Humidite`, `Temperature`, `Ligne_Mesure`) VALUES
(1, '2019-02-28', '09:00:02', 0, 30, 16000, 0, 0, 0, 'Panneau 1'),
(2, '2019-02-28', '10:00:00', 5, 230, 1500, 0, 0, 0, ''),
(3, '2019-02-28', '11:00:00', 14, 30, 16000, 0, 0, 0, ''),
(4, '2019-02-28', '12:00:00', 3, 160, 3200, 0, 0, 0, ''),
(5, '2019-02-28', '13:00:00', 7, 290, 8500, 0, 0, 0, ''),
(7, '0000-00-00', '00:00:00', 69, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(8, '0000-00-00', '00:00:00', 69, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(9, '2019-03-28', '00:00:00', 69, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(10, '2019-03-28', '838:59:59', 69, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(11, '2019-03-28', '00:00:14', 150, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(12, '2019-03-28', '14:52:59', 69, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(13, '2019-03-28', '15:54:32', 69, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(14, '2019-03-28', '16:13:19', 0, 0, 0, 0, 0, 0, ''),
(15, '2019-03-28', '16:14:53', 50, 69, 1500, 0, 0, 0, ''),
(16, '2019-03-28', '16:16:56', 50, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(17, '2019-04-01', '14:22:12', 50, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(18, '2019-04-01', '14:26:53', 50, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(19, '2019-04-01', '15:59:24', 50, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(20, '2019-04-01', '16:00:04', 50, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(21, '2019-04-01', '16:00:25', 50, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(22, '2019-04-01', '16:14:46', 0, 0, 0, 0, 0, 0, ''),
(23, '2019-04-01', '16:16:15', 50, 69, 1500, 30, 1020, 301, 'Prise_JardinHTTP/1.1Host:');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
