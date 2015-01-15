SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Faculties` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Departments` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Faculties_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  INDEX `fk_Departments_Faculties_idx` (`Faculties_ID` ASC),
  CONSTRAINT `fk_Departments_Faculties`
    FOREIGN KEY (`Faculties_ID`)
    REFERENCES `mydb`.`Faculties` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Professors` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Departments_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  INDEX `fk_Professors_Departments1_idx` (`Departments_ID` ASC),
  CONSTRAINT `fk_Professors_Departments1`
    FOREIGN KEY (`Departments_ID`)
    REFERENCES `mydb`.`Departments` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Titles` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(45) NOT NULL,
  `Professors_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  INDEX `fk_Titles_Professors1_idx` (`Professors_ID` ASC),
  CONSTRAINT `fk_Titles_Professors1`
    FOREIGN KEY (`Professors_ID`)
    REFERENCES `mydb`.`Professors` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Courses` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Subject` VARCHAR(45) NOT NULL,
  `Professors_ID` INT NOT NULL,
  `Departments_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  INDEX `fk_Courses_Professors1_idx` (`Professors_ID` ASC),
  INDEX `fk_Courses_Departments1_idx` (`Departments_ID` ASC),
  CONSTRAINT `fk_Courses_Professors1`
    FOREIGN KEY (`Professors_ID`)
    REFERENCES `mydb`.`Professors` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_Departments1`
    FOREIGN KEY (`Departments_ID`)
    REFERENCES `mydb`.`Departments` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Students` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Faculties_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  INDEX `fk_Students_Faculties1_idx` (`Faculties_ID` ASC),
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`Faculties_ID`)
    REFERENCES `mydb`.`Faculties` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`StudentsCourses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`StudentsCourses` (
  `Students_ID` INT NOT NULL,
  `Courses_ID` INT NOT NULL,
  INDEX `fk_StudentsCourses_Students1_idx` (`Students_ID` ASC),
  INDEX `fk_StudentsCourses_Courses1_idx` (`Courses_ID` ASC),
  PRIMARY KEY (`Students_ID`, `Courses_ID`),
  CONSTRAINT `fk_StudentsCourses_Students1`
    FOREIGN KEY (`Students_ID`)
    REFERENCES `mydb`.`Students` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_StudentsCourses_Courses1`
    FOREIGN KEY (`Courses_ID`)
    REFERENCES `mydb`.`Courses` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
