

CREATE DATABASE versenylovak;
use versenylovak;

DROP TABLE IF EXISTS `versenylo`;
DROP TABLE IF EXISTS `istallo`;

CREATE TABLE `versenylo` (
  `id` int(32) NOT NULL,
  `nev`varchar(50) NOT NULL,
  `istalloId` int(32) NOT NULL,
  `fajta` varchar(50) DEFAULT NULL,
  `szuletesidatum` date DEFAULT NULL,
  `versenyekszama` int(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `istallo` (
  `id` int(32) NOT NULL,
  `istallonev` varchar(100) DEFAULT NULL
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

ALTER TABLE `versenylo`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `istallo`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `versenylo`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT;

ALTER TABLE `istallo`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT;

ALTER TABLE `versenylo` ADD FOREIGN KEY (`istalloId`) REFERENCES `istallo` (`id`);
