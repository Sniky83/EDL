-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  ven. 14 juin 2019 à 14:58
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
  `Calibre_Max` int(3) NOT NULL,
  `Type_Courant` varchar(10) NOT NULL,
  `A` float NOT NULL,
  `B` float NOT NULL,
  `Nom_Config` varchar(28) NOT NULL,
  `Model` varchar(15) NOT NULL,
  `Marque` varchar(15) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `capteurs`
--

INSERT INTO `capteurs` (`ID`, `Nom`, `Adresse_IP`, `Calibre_Max`, `Type_Courant`, `A`, `B`, `Nom_Config`, `Model`, `Marque`) VALUES
(44, 'Capteur Bleu', '192.168.1.42', 30, 'Alternatif', 0.011, 5.555, 'INT_ALT_A:0.011_B:5.555', 'XP-12', 'W&W');

-- --------------------------------------------------------

--
-- Structure de la table `config_enregistrement`
--

DROP TABLE IF EXISTS `config_enregistrement`;
CREATE TABLE IF NOT EXISTS `config_enregistrement` (
  `ID` int(5) NOT NULL AUTO_INCREMENT,
  `Ligne` int(5) NOT NULL,
  `ID_Capteur` int(11) NOT NULL,
  `Nom_Ligne` varchar(30) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `config_enregistrement`
--

INSERT INTO `config_enregistrement` (`ID`, `Ligne`, `ID_Capteur`, `Nom_Ligne`) VALUES
(39, 1, 44, 'Cuisine');

-- --------------------------------------------------------

--
-- Structure de la table `membres`
--

DROP TABLE IF EXISTS `membres`;
CREATE TABLE IF NOT EXISTS `membres` (
  `ID` tinyint(5) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(25) NOT NULL,
  `Prenom` varchar(25) NOT NULL,
  `MDP` varchar(25) NOT NULL,
  `Admin` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `membres`
--

INSERT INTO `membres` (`ID`, `Nom`, `Prenom`, `MDP`, `Admin`) VALUES
(1, 'Client', 'Jean', '123456', 0);

-- --------------------------------------------------------

--
-- Structure de la table `mesures_conso_heures`
--

DROP TABLE IF EXISTS `mesures_conso_heures`;
CREATE TABLE IF NOT EXISTS `mesures_conso_heures` (
  `ID` int(4) NOT NULL AUTO_INCREMENT,
  `Heure` time NOT NULL,
  `Intensite` float NOT NULL,
  `Puissance` float NOT NULL,
  `kWh` float NOT NULL,
  `ID_config_enregistrement` int(5) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `mesures_conso_instant`
--

DROP TABLE IF EXISTS `mesures_conso_instant`;
CREATE TABLE IF NOT EXISTS `mesures_conso_instant` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Intensite` float NOT NULL,
  `Puissance` float NOT NULL,
  `ID_config_enregistrement` int(5) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=651 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `mesures_conso_jours`
--

DROP TABLE IF EXISTS `mesures_conso_jours`;
CREATE TABLE IF NOT EXISTS `mesures_conso_jours` (
  `ID` int(4) NOT NULL AUTO_INCREMENT,
  `Jour` date NOT NULL,
  `Intensite` float NOT NULL,
  `Puissance` float NOT NULL,
  `kWh` float NOT NULL,
  `ID_config_enregistrement` int(5) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `mesures_conso_mois`
--

DROP TABLE IF EXISTS `mesures_conso_mois`;
CREATE TABLE IF NOT EXISTS `mesures_conso_mois` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Mois` date NOT NULL,
  `Intensite` float NOT NULL,
  `Puissance` float NOT NULL,
  `kWh` float NOT NULL,
  `ID_config_enregistrement` int(5) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `mesures_production_heure`
--

DROP TABLE IF EXISTS `mesures_production_heure`;
CREATE TABLE IF NOT EXISTS `mesures_production_heure` (
  `ID` int(5) NOT NULL AUTO_INCREMENT,
  `Heure` time NOT NULL,
  `Intensite` float NOT NULL,
  `Tension` float NOT NULL,
  `Puissance` float NOT NULL,
  `Energie_KWh` float NOT NULL,
  `Lumiere` float NOT NULL,
  `Humidite` float NOT NULL,
  `Temperature` float NOT NULL,
  `Ligne_Mesure` varchar(30) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `mesures_production_heure`
--

INSERT INTO `mesures_production_heure` (`ID`, `Heure`, `Intensite`, `Tension`, `Puissance`, `Energie_KWh`, `Lumiere`, `Humidite`, `Temperature`, `Ligne_Mesure`) VALUES
(1, '09:00:02', 0, 0, 30, 16000, 0, 0, 0, 'Panneau 1'),
(2, '10:00:00', 5, 0, 230, 1500, 0, 0, 0, ''),
(3, '11:00:00', 14, 0, 30, 16000, 0, 0, 0, ''),
(4, '12:00:00', 3, 0, 160, 3200, 0, 0, 0, ''),
(5, '13:00:00', 7, 0, 290, 8500, 0, 0, 0, ''),
(7, '00:00:00', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(9, '00:00:00', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(12, '14:52:59', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(13, '15:54:32', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(14, '16:13:19', 0, 0, 0, 0, 0, 0, 0, ''),
(15, '16:14:53', 50, 0, 69, 1500, 0, 0, 0, ''),
(16, '16:16:56', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(17, '14:22:12', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(18, '14:26:53', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(19, '15:59:24', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(20, '16:00:04', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(21, '16:00:25', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(22, '16:14:46', 0, 0, 0, 0, 0, 0, 0, ''),
(23, '16:16:15', 50, 0, 69, 1500, 30, 1020, 301, 'Prise_JardinHTTP/1.1Host:');

-- --------------------------------------------------------

--
-- Structure de la table `mesures_production_instant`
--

DROP TABLE IF EXISTS `mesures_production_instant`;
CREATE TABLE IF NOT EXISTS `mesures_production_instant` (
  `ID` int(99) NOT NULL AUTO_INCREMENT,
  `Enregistrement` int(5) NOT NULL,
  `Intensite` float NOT NULL,
  `Puissance` float NOT NULL,
  `Tension` float NOT NULL,
  `Lumiere` float NOT NULL,
  `Humidite` float NOT NULL,
  `Temperature` float NOT NULL,
  `Ligne_Mesure` varchar(30) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `mesures_production_instant`
--

INSERT INTO `mesures_production_instant` (`ID`, `Enregistrement`, `Intensite`, `Puissance`, `Tension`, `Lumiere`, `Humidite`, `Temperature`, `Ligne_Mesure`) VALUES
(1, 1, 1, 1, 1, 1, 1, 1, '5'),
(2, 2, 2, 2, 2, 2, 2, 2, '6'),
(3, 3, 3, 3, 3, 3, 3, 3, '3'),
(4, 4, 4, 4, 4, 4, 4, 4, '75');

-- --------------------------------------------------------

--
-- Structure de la table `mesures_production_jours`
--

DROP TABLE IF EXISTS `mesures_production_jours`;
CREATE TABLE IF NOT EXISTS `mesures_production_jours` (
  `ID` int(5) NOT NULL AUTO_INCREMENT,
  `Jour` date NOT NULL,
  `Intensite` float NOT NULL,
  `Tension` float NOT NULL,
  `Puissance` float NOT NULL,
  `Energie_KWh` float NOT NULL,
  `Lumiere` float NOT NULL,
  `Humidite` float NOT NULL,
  `Temperature` float NOT NULL,
  `Ligne_Mesure` varchar(30) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `mesures_production_jours`
--

INSERT INTO `mesures_production_jours` (`ID`, `Jour`, `Intensite`, `Tension`, `Puissance`, `Energie_KWh`, `Lumiere`, `Humidite`, `Temperature`, `Ligne_Mesure`) VALUES
(1, '2019-05-13', 0, 0, 30, 16000, 0, 0, 0, 'Panneau 1'),
(2, '2019-05-13', 5, 0, 230, 1500, 0, 0, 0, ''),
(3, '2019-05-13', 14, 0, 30, 16000, 0, 0, 0, ''),
(4, '2019-05-13', 3, 0, 160, 3200, 0, 0, 0, ''),
(5, '2019-05-13', 7, 0, 290, 8500, 0, 0, 0, ''),
(7, '2019-05-13', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(9, '2019-05-13', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(12, '2019-05-13', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(13, '2019-05-13', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(14, '2019-05-13', 0, 0, 0, 0, 0, 0, 0, ''),
(15, '2019-05-13', 50, 0, 69, 1500, 0, 0, 0, ''),
(16, '2019-05-13', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(17, '2019-05-13', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(18, '2019-05-13', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(19, '2019-05-13', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(20, '2019-05-13', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(21, '2019-05-25', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(22, '2019-05-27', 0, 0, 0, 0, 0, 0, 0, ''),
(23, '2019-05-30', 50, 0, 69, 1500, 30, 1020, 301, 'Prise_JardinHTTP/1.1Host:');

-- --------------------------------------------------------

--
-- Structure de la table `mesures_production_mois`
--

DROP TABLE IF EXISTS `mesures_production_mois`;
CREATE TABLE IF NOT EXISTS `mesures_production_mois` (
  `ID` int(5) NOT NULL AUTO_INCREMENT,
  `Mois` date NOT NULL,
  `Intensite` float NOT NULL,
  `Tension` float NOT NULL,
  `Puissance` float NOT NULL,
  `Energie_KWh` float NOT NULL,
  `Lumiere` float NOT NULL,
  `Humidite` float NOT NULL,
  `Temperature` float NOT NULL,
  `Ligne_Mesure` varchar(30) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `mesures_production_mois`
--

INSERT INTO `mesures_production_mois` (`ID`, `Mois`, `Intensite`, `Tension`, `Puissance`, `Energie_KWh`, `Lumiere`, `Humidite`, `Temperature`, `Ligne_Mesure`) VALUES
(1, '2019-05-13', 0, 0, 30, 16000, 0, 0, 0, 'Panneau 1'),
(2, '2019-05-13', 5, 0, 230, 1500, 0, 0, 0, ''),
(3, '2019-05-13', 14, 0, 30, 16000, 0, 0, 0, ''),
(4, '2019-05-13', 3, 0, 160, 3200, 0, 0, 0, ''),
(5, '2019-05-13', 7, 0, 290, 8500, 0, 0, 0, ''),
(7, '2019-05-13', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(9, '2019-05-13', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(12, '2019-05-13', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(13, '2019-05-13', 69, 0, 42, 1337, 0, 0, 0, 'Ligne_Chambre'),
(14, '2019-05-13', 0, 0, 0, 0, 0, 0, 0, ''),
(15, '2019-05-13', 50, 0, 69, 1500, 0, 0, 0, ''),
(16, '2019-05-13', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(17, '2019-05-13', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(18, '2019-05-13', 50, 0, 69, 1500, 0, 0, 0, 'Prise_Jardin'),
(19, '2019-05-13', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(20, '2019-05-13', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(21, '2019-05-13', 50, 0, 69, 1500, 10, 11, 50, 'Prise_Jardin'),
(22, '2019-05-13', 0, 0, 0, 0, 0, 0, 0, ''),
(23, '2019-05-13', 50, 0, 69, 1500, 30, 1020, 301, 'Prise_JardinHTTP/1.1Host:');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
