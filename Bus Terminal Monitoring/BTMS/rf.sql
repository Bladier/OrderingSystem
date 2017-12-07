/*
Navicat MySQL Data Transfer

Source Server         : newlocalhost
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : rf

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2017-12-07 16:54:45
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblbus
-- ----------------------------
INSERT INTO `tblbus` VALUES ('3', 'Aircon', '60', 'AJD 2333', '2', 'Available', '1', '2209');
INSERT INTO `tblbus` VALUES ('4', 'Aircon', '60', 'DFSDF 12302', '2', 'Available', '1', 'DF 123');

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
  `DateHired` date DEFAULT NULL,
  PRIMARY KEY (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblbusperson
-- ----------------------------
INSERT INTO `tblbusperson` VALUES ('1', 'Steve', '', 'Salon', '1992-12-11', 'Condoctor', '1', '1', null);
INSERT INTO `tblbusperson` VALUES ('2', 'john', '', 'Brown', '2017-11-20', 'Driver', '1', '1', null);
INSERT INTO `tblbusperson` VALUES ('3', 'sanple', 'sample', 'sample', '2017-11-27', 'Driver', '1', '1', null);

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblbustransaction
-- ----------------------------
INSERT INTO `tblbustransaction` VALUES ('1', '3', '57', 'C', '2017-11-01');

-- ----------------------------
-- Table structure for `tblbustype`
-- ----------------------------
DROP TABLE IF EXISTS `tblbustype`;
CREATE TABLE `tblbustype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `BusType` varchar(20) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblcredit
-- ----------------------------
INSERT INTO `tblcredit` VALUES ('1', '2', '5588.799999999999');
INSERT INTO `tblcredit` VALUES ('2', '1', '3000');

-- ----------------------------
-- Table structure for `tbldaily`
-- ----------------------------
DROP TABLE IF EXISTS `tbldaily`;
CREATE TABLE `tbldaily` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CurrentDate` date NOT NULL,
  `Status` varchar(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbldaily
-- ----------------------------
INSERT INTO `tbldaily` VALUES ('8', '2017-11-28', '0');
INSERT INTO `tbldaily` VALUES ('9', '2017-11-30', '0');
INSERT INTO `tbldaily` VALUES ('10', '2017-11-29', '1');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblpassenger
-- ----------------------------
INSERT INTO `tblpassenger` VALUES ('1', '3110359101', 'Steves', '', 'Salon', '2017-11-16', '9202929302', 'Regular', 'Soledad State', '11/16/2017 12:00:00 AM', 'General Santos City', 'South Cot.', '', '', '2019-12-10');
INSERT INTO `tblpassenger` VALUES ('2', '3110345429', 'MICA', '', 'LEGISNIANA', '1996-06-10', '9123123123', 'Senior', 'PUROK 6', '6/10/1996 12:00:00 AM', 'KORONADAL', 'SOUTH COT.', 'Senior', '898080980', '2021-12-27');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblroute
-- ----------------------------
INSERT INTO `tblroute` VALUES ('1', 'Gensan', 'Davao', '260', '3');
INSERT INTO `tblroute` VALUES ('2', 'Gensan', 'Davao', '200', '5');

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
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbltransaction
-- ----------------------------
INSERT INTO `tbltransaction` VALUES ('9', '2017-11-26', '2', '3', '244.4', '15.6', '1', '', '1');
INSERT INTO `tbltransaction` VALUES ('10', '2017-11-26', '1', '3', '260', '0', '1', '', '1');
INSERT INTO `tbltransaction` VALUES ('13', '2017-11-26', '1', '3', '260', '0', '1', '', '2');
INSERT INTO `tbltransaction` VALUES ('14', '2017-11-26', '2', '3', '244.4', '15.6', '1', '', '2');

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
