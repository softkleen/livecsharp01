using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace livecsharp.Classes
{
    public static class Banco
    {
        public static MySqlCommand Abrir() 
        {
            MySqlCommand cmd = new MySqlCommand();
            string strCon = @"server=127.0.0.1;database=liveescolardb;user id=root;password=";
            MySqlConnection cn = new MySqlConnection(strCon);
            cn.Open();
            cmd.Connection = cn;
            return cmd;
        }
    }

    /*
     * Pratique!!!!!
     -- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema liveescolardb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema liveescolardb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `liveescolardb` DEFAULT CHARACTER SET utf8 ;
USE `liveescolardb` ;

-- -----------------------------------------------------
-- Table `liveescolardb`.`alunos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `liveescolardb`.`alunos` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `telefone` VARCHAR(45) NULL,
  `senha` VARCHAR(45) NOT NULL,
  `ativo` BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) )
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

     
     */
}
