/*
Navicat MySQL Data Transfer

Source Server         : NewLocalhost
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : os

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2017-10-11 10:03:16
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `tblbillorder`
-- ----------------------------
DROP TABLE IF EXISTS `tblbillorder`;
CREATE TABLE `tblbillorder` (
  `ID` int(15) NOT NULL AUTO_INCREMENT,
  `QUEUEID` int(15) DEFAULT NULL,
  `STATUS` varchar(1) DEFAULT '1',
  `CASH` double DEFAULT NULL,
  `AMOUNTDUE` double DEFAULT NULL,
  `CHANGE` double DEFAULT NULL,
  `ENCODEDBY` int(11) DEFAULT NULL,
  `DOCDATE` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblbillorder
-- ----------------------------

-- ----------------------------
-- Table structure for `tblmaintenance`
-- ----------------------------
DROP TABLE IF EXISTS `tblmaintenance`;
CREATE TABLE `tblmaintenance` (
  `ID` int(15) NOT NULL AUTO_INCREMENT,
  `M_KEY` varchar(50) DEFAULT NULL,
  `M_VALUE` varchar(100) DEFAULT NULL,
  `REMARKS` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblmaintenance
-- ----------------------------

-- ----------------------------
-- Table structure for `tblmenu`
-- ----------------------------
DROP TABLE IF EXISTS `tblmenu`;
CREATE TABLE `tblmenu` (
  `ID` int(15) NOT NULL AUTO_INCREMENT,
  `MENUNAME` varchar(30) DEFAULT NULL,
  `MENUTYPE` varchar(100) DEFAULT NULL,
  `MENUSIZE` varchar(50) DEFAULT NULL,
  `PRICE` double DEFAULT NULL,
  `STATUS` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblmenu
-- ----------------------------

-- ----------------------------
-- Table structure for `tblqueue`
-- ----------------------------
DROP TABLE IF EXISTS `tblqueue`;
CREATE TABLE `tblqueue` (
  `ID` int(15) NOT NULL AUTO_INCREMENT,
  `ORDRENUM` varchar(30) DEFAULT NULL,
  `DATE` datetime DEFAULT NULL,
  `STATUS` varchar(10) DEFAULT NULL COMMENT '''SERVED'' ''CANCEL'' ''PENDING''',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblqueue
-- ----------------------------

-- ----------------------------
-- Table structure for `tblqueueinfo`
-- ----------------------------
DROP TABLE IF EXISTS `tblqueueinfo`;
CREATE TABLE `tblqueueinfo` (
  `ID` int(15) NOT NULL AUTO_INCREMENT,
  `QUEUEID` int(15) DEFAULT NULL,
  `MENUID` int(15) DEFAULT NULL,
  `QTY` int(11) DEFAULT NULL,
  `STATUS` varchar(1) DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblqueueinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `tbluser`
-- ----------------------------
DROP TABLE IF EXISTS `tbluser`;
CREATE TABLE `tbluser` (
  `ID` int(15) NOT NULL AUTO_INCREMENT,
  `USERNAME` varchar(30) DEFAULT NULL,
  `USERPASS` varchar(30) DEFAULT NULL,
  `FIRSTNAME` varchar(30) DEFAULT NULL,
  `MIDDLENAME` varchar(30) NOT NULL,
  `LASTNAME` varchar(30) DEFAULT NULL,
  `STATUS` varchar(1) DEFAULT '1',
  `USERTYPE` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbluser
-- ----------------------------
