/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : rf

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2017-12-06 22:38:22
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `adminpass`
-- ----------------------------
DROP TABLE IF EXISTS `adminpass`;
CREATE TABLE `adminpass` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `user` varchar(10) NOT NULL,
  `pass` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of adminpass
-- ----------------------------
INSERT INTO `adminpass` VALUES ('1', 'admin', 'admin');

-- ----------------------------
-- Table structure for `tblbus`
-- ----------------------------
DROP TABLE IF EXISTS `tblbus`;
CREATE TABLE `tblbus` (
  `busid` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(10) NOT NULL,
  `seat` int(11) NOT NULL,
  `plateno` varchar(20) NOT NULL,
  `driverno` int(11) NOT NULL,
  `Status` varchar(20) DEFAULT NULL,
  `condoctorID` int(11) NOT NULL,
  `Busno` varchar(20) NOT NULL,
  PRIMARY KEY (`busid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblbus
-- ----------------------------
INSERT INTO `tblbus` VALUES ('5', 'Aircon', '60', 'SDF 20231', '6', 'Available', '8', 'KFK 2322');

-- ----------------------------
-- Table structure for `tblbusperson`
-- ----------------------------
DROP TABLE IF EXISTS `tblbusperson`;
CREATE TABLE `tblbusperson` (
  `personid` int(11) NOT NULL AUTO_INCREMENT,
  `finame` varchar(20) NOT NULL,
  `miname` varchar(20) DEFAULT NULL,
  `laname` varchar(20) NOT NULL,
  `bday` date NOT NULL,
  `position` varchar(20) NOT NULL,
  `Status` varchar(1) NOT NULL DEFAULT '1',
  `IsAssigned` int(1) NOT NULL,
  PRIMARY KEY (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblbusperson
-- ----------------------------
INSERT INTO `tblbusperson` VALUES ('5', 'John', '', 'Steve', '1991-04-05', 'Driver', '1', '0');
INSERT INTO `tblbusperson` VALUES ('6', 'Von ', '', 'Jovi', '1994-06-21', 'Driver', '1', '0');
INSERT INTO `tblbusperson` VALUES ('7', 'JOEY', '', 'TAN', '1998-06-10', 'Driver', '1', '0');
INSERT INTO `tblbusperson` VALUES ('8', 'BEN', '', 'TOY', '1988-12-26', 'Condoctor', '1', '0');

-- ----------------------------
-- Table structure for `tblbustransaction`
-- ----------------------------
DROP TABLE IF EXISTS `tblbustransaction`;
CREATE TABLE `tblbustransaction` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `busID` int(11) NOT NULL,
  `AvailableSeat` int(11) NOT NULL,
  `Status` varchar(1) NOT NULL,
  `transDate` date NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblbustransaction
-- ----------------------------
INSERT INTO `tblbustransaction` VALUES ('4', '5', '50', 'T', '2017-12-05');

-- ----------------------------
-- Table structure for `tblbustype`
-- ----------------------------
DROP TABLE IF EXISTS `tblbustype`;
CREATE TABLE `tblbustype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `BusType` varchar(20) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblbustype
-- ----------------------------
INSERT INTO `tblbustype` VALUES ('1', 'Aircon');
INSERT INTO `tblbustype` VALUES ('2', 'Exclusive');

-- ----------------------------
-- Table structure for `tblcredit`
-- ----------------------------
DROP TABLE IF EXISTS `tblcredit`;
CREATE TABLE `tblcredit` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `passID` int(11) NOT NULL,
  `Credit` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblcredit
-- ----------------------------
INSERT INTO `tblcredit` VALUES ('4', '4', '4000');

-- ----------------------------
-- Table structure for `tbldaily`
-- ----------------------------
DROP TABLE IF EXISTS `tbldaily`;
CREATE TABLE `tbldaily` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CurrentDate` date NOT NULL,
  `Status` varchar(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbldaily
-- ----------------------------
INSERT INTO `tbldaily` VALUES ('12', '2017-12-05', '1');

-- ----------------------------
-- Table structure for `tblpassenger`
-- ----------------------------
DROP TABLE IF EXISTS `tblpassenger`;
CREATE TABLE `tblpassenger` (
  `passid` int(6) NOT NULL AUTO_INCREMENT,
  `RFIDNUM` bigint(20) DEFAULT NULL,
  `fname` varchar(20) NOT NULL,
  `mname` varchar(20) NOT NULL,
  `lname` varchar(20) NOT NULL,
  `bday` date DEFAULT NULL,
  `phone` bigint(6) DEFAULT NULL,
  `passtype` varchar(10) NOT NULL,
  `Street` varchar(60) DEFAULT NULL,
  `Brgy` varchar(40) DEFAULT NULL,
  `City` varchar(30) DEFAULT NULL,
  `Province` varchar(40) DEFAULT NULL,
  `IDTYPE` varchar(20) DEFAULT NULL,
  `IDNumber` varchar(20) DEFAULT '0',
  `CardExpiration` date DEFAULT NULL,
  PRIMARY KEY (`passid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblpassenger
-- ----------------------------
INSERT INTO `tblpassenger` VALUES ('4', '2987123123', 'MICA', '', 'LEGISNIANA', '1994-06-09', '1923901293', 'Regular', 'LABOS SOLEDAD STATE', 'CITY HEIGHTS', 'GENERAL SANTOS CITY', 'SOUTH COT', '', '', '2019-12-19');

-- ----------------------------
-- Table structure for `tblroute`
-- ----------------------------
DROP TABLE IF EXISTS `tblroute`;
CREATE TABLE `tblroute` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `From` varchar(30) DEFAULT NULL,
  `Destination` varchar(30) DEFAULT NULL,
  `Rate` double DEFAULT NULL,
  `busID` int(10) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblroute
-- ----------------------------
INSERT INTO `tblroute` VALUES ('4', 'GENSAN', 'DAVAO', '200', '5');

-- ----------------------------
-- Table structure for `tbltransaction`
-- ----------------------------
DROP TABLE IF EXISTS `tbltransaction`;
CREATE TABLE `tbltransaction` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TransDate` date NOT NULL,
  `passID` int(11) NOT NULL,
  `busID` int(11) NOT NULL,
  `Rate` double NOT NULL DEFAULT '0',
  `Discount` double NOT NULL DEFAULT '0',
  `Status` smallint(11) NOT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `busTransID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbltransaction
-- ----------------------------
INSERT INTO `tbltransaction` VALUES ('25', '2017-12-05', '4', '5', '200', '0', '1', '', '4');

-- ----------------------------
-- Table structure for `tbluser`
-- ----------------------------
DROP TABLE IF EXISTS `tbluser`;
CREATE TABLE `tbluser` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `USERNAME` varchar(30) NOT NULL,
  `USERPASS` varchar(30) NOT NULL,
  `FIRSTNAME` varchar(30) NOT NULL,
  `MIDDLENAME` varchar(30) DEFAULT NULL,
  `LASTNAME` varchar(30) NOT NULL,
  `STATUS` varchar(1) NOT NULL,
  `USERTYPE` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tbluser
-- ----------------------------
INSERT INTO `tbluser` VALUES ('1', 'admin', 'myN/8XCodM4=', 'Mica', null, 'Legisniana', '1', 'Admin');
INSERT INTO `tbluser` VALUES ('2', 'ins', 'myN/8XCodM4=', 'Mica', null, 'Legisniana', '1', 'Inspector');

-- ----------------------------
-- View structure for `bus_sales`
-- ----------------------------
DROP VIEW IF EXISTS `bus_sales`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `bus_sales` AS select `t`.`ID` AS `ID`,`t`.`TransDate` AS `TransDate`,`t`.`passID` AS `passID`,`t`.`busID` AS `busID`,`t`.`Rate` AS `Fare`,`t`.`Discount` AS `Discount`,`t`.`Status` AS `TransStatus`,`t`.`remarks` AS `remarks`,`t`.`busTransID` AS `busTransID`,`p`.`RFIDNUM` AS `RFIDNUM`,concat(`p`.`fname`,' ',`p`.`mname`,' ',`p`.`lname`) AS `Fullname`,`p`.`bday` AS `bday`,`p`.`phone` AS `phone`,`p`.`passtype` AS `passtype`,concat(`p`.`Street`,' ',`p`.`Brgy`,' ',`p`.`City`,' ',`p`.`Province`) AS `Address`,`p`.`IDTYPE` AS `IDTYPE`,`p`.`IDNumber` AS `IDNumber`,`p`.`CardExpiration` AS `CardExpiration`,`b`.`type` AS `type`,`b`.`seat` AS `seat`,`b`.`plateno` AS `plateno`,`b`.`Status` AS `Status`,concat(`bp2`.`finame`,' ',`bp2`.`laname`) AS `Condoctor`,concat(`bp`.`finame`,' ',`bp`.`laname`) AS `Driver`,`b`.`Busno` AS `Busno`,concat(`r`.`From`,' ',`r`.`Destination`) AS `Route`,`r`.`Rate` AS `Rate`,`bt`.`AvailableSeat` AS `AvailableSeat`,`bt`.`Status` AS `BusTransStatus`,(`b`.`seat` - `bt`.`AvailableSeat`) AS `passengers`,`bt`.`ID` AS `BTransID`,`bt`.`transDate` AS `BTransDate` from ((((((`tbltransaction` `t` join `tblpassenger` `p` on((`p`.`passid` = `t`.`passID`))) join `tblbus` `b` on((`b`.`busid` = `t`.`busID`))) join `tblbusperson` `bp2` on((`b`.`condoctorID` = `bp2`.`personid`))) join `tblbusperson` `bp` on((`b`.`driverno` = `bp`.`personid`))) join `tblbustransaction` `bt` on((`bt`.`ID` = `t`.`busTransID`))) join `tblroute` `r` on((`r`.`busID` = `t`.`busID`)));

-- ----------------------------
-- View structure for `buslisttransaction`
-- ----------------------------
DROP VIEW IF EXISTS `buslisttransaction`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `buslisttransaction` AS select `tblbustransaction`.`busID` AS `busID`,`tblbustransaction`.`ID` AS `ID`,`tblbustransaction`.`AvailableSeat` AS `AvailableSeat`,`tblbustransaction`.`Status` AS `Status`,`tblbus`.`type` AS `type`,`tblbus`.`seat` AS `seat`,`tblbus`.`plateno` AS `plateno`,`tblbus`.`condoctorID` AS `condoctorID`,`tblbus`.`driverno` AS `driverno`,`tblbus`.`Busno` AS `Busno` from (`tblbus` join `tblbustransaction` on((`tblbustransaction`.`busID` = `tblbus`.`busid`)));

-- ----------------------------
-- View structure for `passengertransaction`
-- ----------------------------
DROP VIEW IF EXISTS `passengertransaction`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `passengertransaction` AS select distinct `tbltransaction`.`ID` AS `ID`,`tbltransaction`.`TransDate` AS `TransDate`,`tblpassenger`.`RFIDNUM` AS `RFIDNUM`,`tblpassenger`.`fname` AS `fname`,`tblpassenger`.`mname` AS `mname`,`tblpassenger`.`lname` AS `lname`,`tbltransaction`.`passID` AS `passID`,`tbltransaction`.`busID` AS `busID`,`tblbus`.`type` AS `type`,`tblbus`.`Busno` AS `Busno`,`tblroute`.`From` AS `From`,`tblroute`.`Destination` AS `Destination`,`tbltransaction`.`Status` AS `Status`,`tblcredit`.`Credit` AS `Credit`,`tblcredit`.`ID` AS `creditID`,`tbltransaction`.`Rate` AS `Rate`,`tblbustransaction`.`ID` AS `busTransID`,`tblbustransaction`.`AvailableSeat` AS `AvailableSeat` from (((((`tbltransaction` join `tblpassenger` on((`tblpassenger`.`passid` = `tbltransaction`.`passID`))) join `tblbus` on((`tblbus`.`busid` = `tbltransaction`.`busID`))) join `tblroute` on((`tblroute`.`busID` = `tblbus`.`busid`))) join `tblcredit` on((`tblcredit`.`ID` = `tblpassenger`.`passid`))) join `tblbustransaction` on((`tblbustransaction`.`ID` = `tbltransaction`.`busTransID`)));
