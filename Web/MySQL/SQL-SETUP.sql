-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3306
-- Tiempo de generación: 01-03-2019 a las 14:46:25
-- Versión del servidor: 10.3.13-MariaDB
-- Versión de PHP: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `id8378875_makerlabdev`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ClavesRegistro`
--

CREATE TABLE `ClavesRegistro` (
  `claveRegistro` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `Usuario` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Cuentas`
--

CREATE TABLE `Cuentas` (
  `IDcuenta` int(11) NOT NULL,
  `Usuario` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `Contraseña` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Baneado` tinyint(4) NOT NULL DEFAULT 0,
  `Premium` tinyint(4) NOT NULL DEFAULT 0,
  `ClaveSesion` varchar(15) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Datos`
--

CREATE TABLE `Datos` (
  `Usuario` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `Dato` text COLLATE utf8_unicode_ci DEFAULT NULL,
  `Dato2` text COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Notificaciones`
--

CREATE TABLE `Notificaciones` (
  `IDNotificacion` int(11) NOT NULL,
  `Titulo` text COLLATE utf8_unicode_ci DEFAULT NULL,
  `Contenido` text COLLATE utf8_unicode_ci DEFAULT NULL,
  `Personal` tinyint(4) NOT NULL,
  `Usuario` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Tickets`
--

CREATE TABLE `Tickets` (
  `IDTicket` int(11) NOT NULL,
  `Usuario` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `Contenido` text COLLATE utf8_unicode_ci NOT NULL,
  `Respuesta` text COLLATE utf8_unicode_ci DEFAULT NULL,
  `Estado` varchar(30) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `ClavesRegistro`
--
ALTER TABLE `ClavesRegistro`
  ADD PRIMARY KEY (`claveRegistro`);

--
-- Indices de la tabla `Cuentas`
--
ALTER TABLE `Cuentas`
  ADD PRIMARY KEY (`IDcuenta`);

--
-- Indices de la tabla `Datos`
--
ALTER TABLE `Datos`
  ADD PRIMARY KEY (`Usuario`);

--
-- Indices de la tabla `Notificaciones`
--
ALTER TABLE `Notificaciones`
  ADD PRIMARY KEY (`IDNotificacion`);

--
-- Indices de la tabla `Tickets`
--
ALTER TABLE `Tickets`
  ADD PRIMARY KEY (`IDTicket`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `Cuentas`
--
ALTER TABLE `Cuentas`
  MODIFY `IDcuenta` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `Notificaciones`
--
ALTER TABLE `Notificaciones`
  MODIFY `IDNotificacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `Tickets`
--
ALTER TABLE `Tickets`
  MODIFY `IDTicket` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
