CREATE TABLE `OperatorProfile` (
  `OperatorProfileId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(40) DEFAULT NULL,
  `Email` varchar(60) DEFAULT NULL,
  `Birthday` datetime DEFAULT NULL,
  `Gender` int(3) DEFAULT NULL,
  `Age` int(3) DEFAULT NULL,
  `DtCreated` datetime DEFAULT NULL,
  `DtModified` datetime DEFAULT NULL,
  `RowVer` int(11) DEFAULT NULL,
  PRIMARY KEY (`OperatorProfileId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
