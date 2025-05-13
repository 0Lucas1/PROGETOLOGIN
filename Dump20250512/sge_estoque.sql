-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: sge
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `estoque`
--

DROP TABLE IF EXISTS `estoque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estoque` (
  `ID_Produto` int NOT NULL AUTO_INCREMENT,
  `Quantidade` int NOT NULL,
  `Nome_Produto` varchar(100) NOT NULL,
  `Categoria` varchar(100) NOT NULL,
  `Valor_Compra` decimal(10,2) NOT NULL,
  `Valor_Venda` decimal(10,2) NOT NULL,
  `Fornecedor` varchar(100) NOT NULL,
  `Data_entrada` date DEFAULT NULL,
  `Validade` date DEFAULT NULL,
  PRIMARY KEY (`ID_Produto`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estoque`
--

LOCK TABLES `estoque` WRITE;
/*!40000 ALTER TABLE `estoque` DISABLE KEYS */;
INSERT INTO `estoque` VALUES (9,97,'Arroz','Alimento',10.00,20.00,'Amil','2024-11-10','2026-01-10'),(10,91,'Macarrao','Alimento',4.50,7.00,'Adria','2024-11-10','2026-01-10'),(11,98,'Café','Alimento',20.00,40.00,'Pilão','2024-11-10','2026-01-10'),(12,99,'Feijão','Alimento',15.00,25.00,'Pantera','2024-11-10','2026-01-10'),(13,99,'Detergente','Limpeza',2.00,4.00,'Ype','2024-11-10','2026-01-10'),(14,99,'Sabão em pó','Limpeza',10.00,20.00,'OMO','2024-11-10','2026-01-10'),(15,99,'Agua Sanitária','Limpeza',6.00,10.00,'Candida','2024-11-10','2026-01-10'),(16,99,'Desinfetante','Limpeza',4.00,8.00,'Ype','2024-11-10','2026-01-10'),(17,98,'Papel Higienico','Higiene',10.00,18.00,'Personal','2024-11-10','2026-01-10'),(18,100,'Sabonete','Higiene',1.50,3.00,'Dove','2024-11-10','2026-01-10'),(19,100,'Shampoo','Higiene',8.00,13.00,'Loreal','2024-11-10','2026-01-10'),(20,100,'Condicionador','Higiene',7.00,12.00,'Loreal','2024-11-10','2026-01-10');
/*!40000 ALTER TABLE `estoque` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-12 22:28:31
