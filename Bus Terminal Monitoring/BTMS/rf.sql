/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : rf

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2017-11-22 09:06:06
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
  `driverno` int(11) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  `condoctorID` int(11) DEFAULT NULL,
  PRIMARY KEY (`busid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblbus
-- ----------------------------
INSERT INTO `tblbus` VALUES ('3', 'Aircon', '60', 'AJD 2333', '2', 'For Travel', '1');

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
  PRIMARY KEY (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblbusperson
-- ----------------------------
INSERT INTO `tblbusperson` VALUES ('1', 'Steve', '', 'Salon', '1992-12-11', 'Condoctor', '1');
INSERT INTO `tblbusperson` VALUES ('2', 'john', '', 'Brown', '2017-11-20', 'Driver', '1');

-- ----------------------------
-- Table structure for `tblcredit`
-- ----------------------------
DROP TABLE IF EXISTS `tblcredit`;
CREATE TABLE `tblcredit` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `passID` int(11) NOT NULL,
  `Credit` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblcredit
-- ----------------------------
INSERT INTO `tblCredit` VALUES ('1', '2', '2000');

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
  PRIMARY KEY (`passid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tblpassenger
-- ----------------------------
INSERT INTO `tblpassenger` VALUES ('1', '3110359101', 'Steves', '', 'Salon', '2017-11-16', '9202929302', 'Senior', 'Soledad State', '11/16/2017 12:00:00 AM', 'General Santos City', 'South Cot.', 'Senior', '01923423');
INSERT INTO `tblpassenger` VALUES ('2', '3110345429', 'MICA', '', 'LEGISNIANA', '1996-06-10', '9123123123', 'Senior', 'PUROK 6', '6/10/1996 12:00:00 AM', 'KORONADAL', 'SOUTH COT.', 'Senior', '898080980');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblroute
-- ----------------------------
INSERT INTO `tblroute` VALUES ('1', 'Gensan', 'Davao', '260', '3');
