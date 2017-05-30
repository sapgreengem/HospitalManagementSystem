-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 31, 2016 at 08:48 PM
-- Server version: 10.1.9-MariaDB
-- PHP Version: 5.5.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `user`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`username`, `password`) VALUES
('admin', 'admin'),
('tanvir', 'tanvir');

-- --------------------------------------------------------

--
-- Table structure for table `admitted_medicine`
--

CREATE TABLE `admitted_medicine` (
  `patient_name` varchar(20) NOT NULL,
  `patient_contact_no` varchar(11) NOT NULL,
  `time_of_admission` varchar(11) NOT NULL,
  `patient_age` varchar(3) NOT NULL,
  `disease` varchar(40) NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `quantity` varchar(3) NOT NULL,
  `days` varchar(2) NOT NULL,
  `time_of_day` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admitted_medicine`
--

INSERT INTO `admitted_medicine` (`patient_name`, `patient_contact_no`, `time_of_admission`, `patient_age`, `disease`, `product_name`, `quantity`, `days`, `time_of_day`) VALUES
('Jaowat', '01679074498', '2016-08-31', '22', 'Arthritis', 'Calbo-D', '2', '2', '1-1-1'),
('Jj', '01679074498', '2016-08-31', '2', 'Arthritis', 'Calbo-D', '2', '2', '1-1-1'),
('Jaowat', '01679074498', '2016-08-31', '22', 'Arthritis', 'Napa', '3', '3', '1-1-1'),
('Jj', '01679074498', '2016-08-31', '2', 'Arthritis', 'Napa', '3', '3', '1-1-1'),
('Jaowat', '01750178179', '2016-08-31', '22', 'Arthritis', 'Calbo-D', '3', '3', '1-1-1'),
('Jaowat', '01750178179', '2016-08-31', '22', 'Arthritis', 'Minocycline', '3', '3', '1-1-1');

-- --------------------------------------------------------

--
-- Table structure for table `admitted_medicine_cost`
--

CREATE TABLE `admitted_medicine_cost` (
  `patient_name` varchar(20) NOT NULL,
  `patient_contact_no` varchar(11) NOT NULL,
  `time_of_admission` varchar(11) NOT NULL,
  `patient_age` varchar(3) NOT NULL,
  `disease` varchar(40) NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `quantity` varchar(3) NOT NULL,
  `days` varchar(2) NOT NULL,
  `time_of_day` varchar(30) NOT NULL,
  `selling_price` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admitted_medicine_cost`
--

INSERT INTO `admitted_medicine_cost` (`patient_name`, `patient_contact_no`, `time_of_admission`, `patient_age`, `disease`, `product_name`, `quantity`, `days`, `time_of_day`, `selling_price`) VALUES
('Jaowat', '01679074498', '2016-08-31', '22', 'Arthritis', 'Calbo-D', '2', '2', '1-1-1', '20'),
('Jj', '01679074498', '2016-08-31', '2', 'Arthritis', 'Calbo-D', '2', '2', '1-1-1', '20'),
('Jaowat', '01750178179', '2016-08-31', '22', 'Arthritis', 'Calbo-D', '3', '3', '1-1-1', '20'),
('Jaowat', '01750178179', '2016-08-31', '22', 'Arthritis', 'Minocycline', '3', '3', '1-1-1', '50'),
('Jaowat', '01679074498', '2016-08-31', '22', 'Arthritis', 'Napa', '3', '3', '1-1-1', '3'),
('Jj', '01679074498', '2016-08-31', '2', 'Arthritis', 'Napa', '3', '3', '1-1-1', '3');

-- --------------------------------------------------------

--
-- Table structure for table `admitted_patient`
--

CREATE TABLE `admitted_patient` (
  `patient_name` varchar(20) NOT NULL,
  `patient_age` varchar(3) NOT NULL,
  `patient_contact_no` varchar(11) NOT NULL,
  `patient_blood_group` varchar(5) NOT NULL,
  `patient_address` varchar(50) NOT NULL,
  `patient_disease` varchar(20) NOT NULL,
  `doc_name` varchar(20) NOT NULL,
  `doc_id` varchar(20) NOT NULL,
  `doc_dept` varchar(20) NOT NULL,
  `time_of_admission` varchar(11) NOT NULL,
  `ward_name` varchar(20) NOT NULL,
  `checked_status` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admitted_patient`
--

INSERT INTO `admitted_patient` (`patient_name`, `patient_age`, `patient_contact_no`, `patient_blood_group`, `patient_address`, `patient_disease`, `doc_name`, `doc_id`, `doc_dept`, `time_of_admission`, `ward_name`, `checked_status`) VALUES
('Jaowat', '22', '01679074498', 'A+', 'Mirpur', 'Arthritis', 'Shuvo', 'doc1', 'Orthopedics', '2016-08-31', 'Cardiology', 'Released'),
('Jaowat', '22', '01750178179', 'A+', 'Kafrul', 'Arthritis', 'Shuvo', 'doc1', 'Orthopedics', '2016-08-31', 'Cardiology', 'Released'),
('Jj', '2', '01679074498', 'A+', 'g', 'Arthritis', 'Shuvo', 'doc1', 'Orthopedics', '2016-08-31', 'Cardiology', 'Admitted');

-- --------------------------------------------------------

--
-- Table structure for table `admitted_test`
--

CREATE TABLE `admitted_test` (
  `patient_name` varchar(20) NOT NULL,
  `patient_contact_no` varchar(11) NOT NULL,
  `time_of_admission` varchar(11) NOT NULL,
  `patient_age` varchar(3) NOT NULL,
  `test_name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admitted_test`
--

INSERT INTO `admitted_test` (`patient_name`, `patient_contact_no`, `time_of_admission`, `patient_age`, `test_name`) VALUES
('Jaowat', '01679074498', '2016-08-31', '22', 'X-Ray'),
('Jj', '01679074498', '2016-08-31', '2', 'X-Ray'),
('Jaowat', '01679074498', '2016-08-31', '22', 'Blood Test'),
('Jj', '01679074498', '2016-08-31', '2', 'Blood Test'),
('Jaowat', '01750178179', '2016-08-31', '22', 'X-Ray');

-- --------------------------------------------------------

--
-- Table structure for table `admitted_test_cost`
--

CREATE TABLE `admitted_test_cost` (
  `patient_name` varchar(20) NOT NULL,
  `patient_contact_no` varchar(11) NOT NULL,
  `time_of_admission` varchar(11) NOT NULL,
  `patient_age` varchar(3) NOT NULL,
  `test_name` varchar(30) NOT NULL,
  `test_cost` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admitted_test_cost`
--

INSERT INTO `admitted_test_cost` (`patient_name`, `patient_contact_no`, `time_of_admission`, `patient_age`, `test_name`, `test_cost`) VALUES
('Jaowat', '01679074498', '2016-08-31', '22', 'X-Ray', '200'),
('Jj', '01679074498', '2016-08-31', '2', 'X-Ray', '200'),
('Jaowat', '01750178179', '2016-08-31', '22', 'X-Ray', '200'),
('Jaowat', '01679074498', '2016-08-31', '22', 'Blood Test', '500'),
('Jj', '01679074498', '2016-08-31', '2', 'Blood Test', '500');

-- --------------------------------------------------------

--
-- Table structure for table `allocate_patient_bed`
--

CREATE TABLE `allocate_patient_bed` (
  `patient_name` varchar(20) NOT NULL,
  `patient_age` varchar(3) NOT NULL,
  `patient_contact_no` varchar(11) NOT NULL,
  `ward_name` varchar(20) NOT NULL,
  `bed_no` varchar(5) NOT NULL,
  `bed_type` varchar(10) NOT NULL,
  `bed_cost` varchar(3) NOT NULL,
  `bed_status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `allocate_patient_bed`
--

INSERT INTO `allocate_patient_bed` (`patient_name`, `patient_age`, `patient_contact_no`, `ward_name`, `bed_no`, `bed_type`, `bed_cost`, `bed_status`) VALUES
('Jaowat', '22', '01679074498', 'Cardiology', '1', 'Normal', '300', 'Occupied'),
('Jj', '2', '01679074498', 'Cardiology', '1', 'Normal', '300', 'Occupied');

-- --------------------------------------------------------

--
-- Table structure for table `appointment`
--

CREATE TABLE `appointment` (
  `pat_name` varchar(20) NOT NULL,
  `pat_age` varchar(3) NOT NULL,
  `pat_address` varchar(50) NOT NULL,
  `pat_contact_no` varchar(15) NOT NULL,
  `doc_id` varchar(10) NOT NULL,
  `doc_name` varchar(20) NOT NULL,
  `doc_dept` varchar(20) NOT NULL,
  `appointment_date` varchar(15) NOT NULL,
  `appointment_status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`pat_name`, `pat_age`, `pat_address`, `pat_contact_no`, `doc_id`, `doc_name`, `doc_dept`, `appointment_date`, `appointment_status`) VALUES
('Raihan', '12', 'Kafrul', '01750178179', 'doc1', 'Shuvo', 'Orthopedics', '31-Aug-16', 'Checked');

-- --------------------------------------------------------

--
-- Table structure for table `appointment_medicine`
--

CREATE TABLE `appointment_medicine` (
  `pat_name` varchar(20) NOT NULL,
  `pat_contact_no` varchar(15) NOT NULL,
  `appointment_date` varchar(15) NOT NULL,
  `pat_age` varchar(3) NOT NULL,
  `disease` varchar(40) NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `quantity` varchar(3) NOT NULL,
  `days` varchar(2) NOT NULL,
  `time_of_day` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `appointment_medicine`
--

INSERT INTO `appointment_medicine` (`pat_name`, `pat_contact_no`, `appointment_date`, `pat_age`, `disease`, `product_name`, `quantity`, `days`, `time_of_day`) VALUES
('Raihan', '01750178179', '31-Aug-16', '12', 'Orthopedic', 'Calbo-D', '2', '2', '0-0-1'),
('Raihan', '01750178179', '31-Aug-16', '12', 'Orthopedic', 'Cyclooxygenase-2 inhibitors', '2', '2', '0-0-1');

-- --------------------------------------------------------

--
-- Table structure for table `appointment_test`
--

CREATE TABLE `appointment_test` (
  `pat_name` varchar(20) NOT NULL,
  `pat_contact_no` varchar(15) NOT NULL,
  `appointment_date` varchar(15) NOT NULL,
  `pat_age` varchar(3) NOT NULL,
  `test_name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `appointment_test`
--

INSERT INTO `appointment_test` (`pat_name`, `pat_contact_no`, `appointment_date`, `pat_age`, `test_name`) VALUES
('Raihan', '01750178179', '31-Aug-16', '12', 'Harcvanga'),
('Raihan', '01750178179', '31-Aug-16', '12', 'X-Ray');

-- --------------------------------------------------------

--
-- Table structure for table `bed`
--

CREATE TABLE `bed` (
  `pat_contact_no` varchar(11) NOT NULL,
  `ward_id` varchar(20) NOT NULL,
  `bed_no` varchar(5) NOT NULL,
  `bed_type` varchar(10) NOT NULL,
  `bed_cost` varchar(3) NOT NULL,
  `bed_status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bed`
--

INSERT INTO `bed` (`pat_contact_no`, `ward_id`, `bed_no`, `bed_type`, `bed_cost`, `bed_status`) VALUES
('01679074498', '1', '1', 'Normal', '300', 'Occupied'),
('', '1', '2', 'Normal', '300', 'Free'),
('', '1', '3', 'Normal', '300', 'Free'),
('', '1', '4', 'Normal', '300', 'Free'),
('', '1', '5', 'VIP', '700', 'Free'),
('01679074498', '2', '1', 'Normal', '200', 'Occupied'),
('', '2', '2', 'Normal', '200', 'Free'),
('', '2', '3', 'Normal', '200', 'Free'),
('', '2', '4', 'Normal', '200', 'Free'),
('', '2', '5', 'VIP', '700', 'Free');

-- --------------------------------------------------------

--
-- Table structure for table `blood_bank`
--

CREATE TABLE `blood_bank` (
  `group_name` varchar(3) NOT NULL,
  `quantity` varchar(3) NOT NULL,
  `storage_date` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `blood_bank`
--

INSERT INTO `blood_bank` (`group_name`, `quantity`, `storage_date`) VALUES
('A+', '20', '12/20/2016'),
('O+', '6', '21/12/2016'),
('B+', '40', '01/09/2016'),
('AB+', '20', '21/08/2016'),
('A-', '12', '31/08/2016');

-- --------------------------------------------------------

--
-- Table structure for table `blood_group`
--

CREATE TABLE `blood_group` (
  `name` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `blood_group`
--

INSERT INTO `blood_group` (`name`) VALUES
('A+'),
('A-'),
('AB+'),
('AB-'),
('B+'),
('B-'),
('O+'),
('O-');

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `name` varchar(20) NOT NULL,
  `age` varchar(3) NOT NULL,
  `contact_no` varchar(11) NOT NULL,
  `department` varchar(20) NOT NULL,
  `specialist_in` varchar(20) NOT NULL,
  `address` varchar(50) NOT NULL,
  `join_date` varchar(20) NOT NULL,
  `counsiling_hour` varchar(50) NOT NULL,
  `id` varchar(10) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`name`, `age`, `contact_no`, `department`, `specialist_in`, `address`, `join_date`, `counsiling_hour`, `id`, `password`) VALUES
('Shuvo', '22', '01987123456', 'Orthopedics', 'Surgery', 'Mirpur, Dhaka', '7/27/2016', '2:00pm-6:00pm', 'doc1', 'DOC1'),
('Hasib', '32', '01675443322', 'Cardiology', 'Surgery', 'tejgaon', '7/29/2016', '3:00pm-6:00pm', 'doc2', 'doc2'),
('Pushpak', '32', '01675560322', 'Nurology', 'Paralysis', 'Nabisco, Dhaka', '6/5/2013', '10:00am-12:00pm', 'doc3', 'doc3');

-- --------------------------------------------------------

--
-- Table structure for table `medicine`
--

CREATE TABLE `medicine` (
  `pat_contact_no` varchar(15) NOT NULL,
  `appointment_date` varchar(15) NOT NULL,
  `doc_id` varchar(10) NOT NULL,
  `disease` varchar(40) NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `quantity` varchar(3) NOT NULL,
  `days` varchar(2) NOT NULL,
  `time_of_day` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `medicine`
--

INSERT INTO `medicine` (`pat_contact_no`, `appointment_date`, `doc_id`, `disease`, `product_name`, `quantity`, `days`, `time_of_day`) VALUES
('01679074498', '2016-08-31', 'doc1', 'Arthritis', 'Calbo-D', '2', '2', '1-1-1'),
('01679074498', '2016-08-31', 'doc1', 'Arthritis', 'Napa', '3', '3', '1-1-1'),
('01750178179', '2016-08-31', 'doc1', 'Arthritis', 'Calbo-D', '3', '3', '1-1-1'),
('01750178179', '2016-08-31', 'doc1', 'Arthritis', 'Minocycline', '3', '3', '1-1-1'),
('01750178179', '31-Aug-16', 'doc1', 'Orthopedic', 'Calbo-D', '2', '2', '0-0-1'),
('01750178179', '31-Aug-16', 'doc1', 'Orthopedic', 'Cyclooxygenase-2 inhibitors', '2', '2', '0-0-1');

-- --------------------------------------------------------

--
-- Table structure for table `medicine_name`
--

CREATE TABLE `medicine_name` (
  `medicine_name` varchar(40) NOT NULL,
  `disease_type` varchar(40) NOT NULL,
  `disease_name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `medicine_name`
--

INSERT INTO `medicine_name` (`medicine_name`, `disease_type`, `disease_name`) VALUES
('Abetis', 'Cardiac', 'Hypertension'),
('Aspirin', 'Cardiac', 'Heart Attack'),
('Backaid Inflammatory', 'Cardiac', 'Heart Attack'),
('Calbo-D', 'Orthopedic', 'Arthritis'),
('Cyclooxygenase-2 inhibitors', 'Orthopedic', 'Osteoarthritis'),
('Excedrin', 'Cardiac', 'Hypertension'),
('Gleostine', 'Neurological', 'Brain Damage'),
('kkhkjh', 'Neurological', 'Brain Tumor'),
('Lomustine', 'Neurological', 'Brain Tumor'),
('Minocycline', 'Orthopedic', 'Arthritis'),
('Napa', 'Orthopedic', 'Arthritis'),
('Opioid analgesics', 'Orthopedic', 'Osteoarthritis'),
('Pamprin Max ', 'Neurological', 'Brain Tumor'),
('Vanquish', 'Neurological', 'Brain Damage');

-- --------------------------------------------------------

--
-- Table structure for table `product_type`
--

CREATE TABLE `product_type` (
  `name` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product_type`
--

INSERT INTO `product_type` (`name`) VALUES
('Medicine'),
('Food Item'),
('Water');

-- --------------------------------------------------------

--
-- Table structure for table `release_patient`
--

CREATE TABLE `release_patient` (
  `pat_name` varchar(20) NOT NULL,
  `pat_age` varchar(5) NOT NULL,
  `pat_contact_num` varchar(11) NOT NULL,
  `pat_address` varchar(20) NOT NULL,
  `disease` varchar(20) NOT NULL,
  `doc_name` varchar(20) NOT NULL,
  `date_of_admit` varchar(11) NOT NULL,
  `date_of_release` varchar(11) NOT NULL,
  `num_of_admitted_days` varchar(2) NOT NULL,
  `medicine_cost` varchar(4) NOT NULL,
  `test_cost` varchar(4) NOT NULL,
  `bed_cost` varchar(4) NOT NULL,
  `total_cost` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `release_patient`
--

INSERT INTO `release_patient` (`pat_name`, `pat_age`, `pat_contact_num`, `pat_address`, `disease`, `doc_name`, `date_of_admit`, `date_of_release`, `num_of_admitted_days`, `medicine_cost`, `test_cost`, `bed_cost`, `total_cost`) VALUES
('Jaowat', '22', '01679074498', 'Mirpur', 'Arthritis', 'Shuvo', '2016-08-31', '2016-08-31', '6', '107', '700', '1800', '2607'),
('Jaowat', '22', '01750178179', 'Kafrul', 'Arthritis', 'Shuvo', '2016-08-31', '2016-08-31', '5', '630', '200', '1500', '2330');

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `name` varchar(30) NOT NULL,
  `age` int(3) NOT NULL,
  `contact_num` varchar(11) NOT NULL,
  `post` varchar(20) NOT NULL,
  `blood_group` varchar(5) NOT NULL,
  `join_date` varchar(20) NOT NULL,
  `address` varchar(50) NOT NULL,
  `staff_id` varchar(10) NOT NULL,
  `staff_password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`name`, `age`, `contact_num`, `post`, `blood_group`, `join_date`, `address`, `staff_id`, `staff_password`) VALUES
('Push', 21, '01675560322', 'Reciptionist', 'AB+', '12-13-2016', '5/17 govt printing press', 'staff1', 'staff1'),
('Pushpak', 22, '01750178179', 'Reciptionist', 'B+', '7/27/2016', 'Kafrul, Dhaka', 'staff2', 'staff2');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `company_name` varchar(20) NOT NULL,
  `contact_no` varchar(11) NOT NULL,
  `product_name` varchar(30) NOT NULL,
  `product_type` varchar(20) NOT NULL,
  `purchased_date` varchar(15) NOT NULL,
  `quantity` varchar(4) NOT NULL,
  `buying_price` varchar(5) NOT NULL,
  `selling_price` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`company_name`, `contact_no`, `product_name`, `product_type`, `purchased_date`, `quantity`, `buying_price`, `selling_price`) VALUES
('ACI', '0167443322', 'Abetis', 'Medicine', '8/15/2016', '100', '5', '8'),
('ACMI', '01556423581', 'Aspirine', 'Medicine', '8/15/2016', '200', '2', '5'),
('SQUARE', '01567896321', 'Backaid Inflammatory', 'Medicine', '8/15/2016', '500', '20', '25'),
('ACMI', '01556423581', 'Calbo-D', 'Medicine', '8/15/2016', '600', '15', '20'),
('ACI', '0167443322', 'Cyclooxygenase-2 inhibitors', 'Medicine', '8/15/2016', '300', '30', '34'),
('ACI', '0167443322', 'Excedrin', 'Medicine', '8/15/2016', '400', '5', '7'),
('SQUARE', '01567896321', 'Gleostine', 'Medicine', '8/15/2016', '500', '14', '20'),
('ACMI', '01556423581', 'Lomustine', 'Medicine', '8/15/2016', '350', '8', '12'),
('SQUARE', '01567896321', 'Minocycline', 'Medicine', '8/15/2016', '542', '45', '50'),
('SQUARE', '01567896321', 'Opioid analgesics', 'Medicine', '8/15/2016', '454', '15', '18'),
('ACMI', '01556423581', 'Pamprin Max ', 'Medicine', '8/15/2016', '788', '12', '20'),
('ACI', '0167443322', 'Vanquish', 'Medicine', '8/15/2016', '498', '56', '60'),
('ACI', '123', 'Napa', 'Medicine', '30/08/2016', '50', '2', '3'),
('ACMI', '123456789', 'kkhkjh', 'Medicine', '30/12/26', '855', '20', '25');

-- --------------------------------------------------------

--
-- Table structure for table `test`
--

CREATE TABLE `test` (
  `pat_contact_no` varchar(11) NOT NULL,
  `appointment_date` varchar(15) NOT NULL,
  `doc_id` varchar(10) NOT NULL,
  `disease` varchar(30) NOT NULL,
  `test_name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `test`
--

INSERT INTO `test` (`pat_contact_no`, `appointment_date`, `doc_id`, `disease`, `test_name`) VALUES
('01679074498', '2016-08-31', 'doc1', 'Arthritis', 'X-Ray'),
('01679074498', '2016-08-31', 'doc1', 'Arthritis', 'Blood Test'),
('01750178179', '2016-08-31', 'doc1', 'Arthritis', 'X-Ray'),
('01750178179', '31-Aug-16', 'doc1', 'Orthopedic', 'Harcvanga'),
('01750178179', '31-Aug-16', 'doc1', 'Orthopedic', 'X-Ray');

-- --------------------------------------------------------

--
-- Table structure for table `test_name`
--

CREATE TABLE `test_name` (
  `test_Name` varchar(30) NOT NULL,
  `disease_type` varchar(30) NOT NULL,
  `disease_name` varchar(30) NOT NULL,
  `test_cost` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `test_name`
--

INSERT INTO `test_name` (`test_Name`, `disease_type`, `disease_name`, `test_cost`) VALUES
('BP Test', 'Cardiac', 'Hypertension', '200'),
('Creatinin', 'Cardiac', 'Hypertension', '700'),
('ECG', 'Cardiac', 'Heart Attack', '200'),
('Troponin', 'Cardiac', 'Heart Attack', '1000'),
('CT Scan', 'Neurological', 'Brain Tumor', '4200'),
('MRI', 'Neurological', 'Brain Tumor', '4000'),
('Brain Strom', 'Neurological', 'Brain Damage', '500'),
('CT Scan', 'Neurological', 'Brain Damage', '4200'),
('Harcvanga', 'Orthopedic', 'Osteoarthritis', '200'),
('X-Ray', 'Orthopedic', 'Arthritis', '200'),
('Blood Test', 'Orthopedic', 'Arthritis', '500'),
('Haruvangiab', 'Orthopedic', 'Osteoarthritis', '600'),
('X-Ray-Cardiac', 'Cardiac', 'Heart Attack', '700'),
('X-Ray-Neurological', 'Neurological', 'Brain Tumor', '300'),
('Delete', 'Neurological', 'Brain Tumor', '200');

-- --------------------------------------------------------

--
-- Table structure for table `timing`
--

CREATE TABLE `timing` (
  `timing` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `timing`
--

INSERT INTO `timing` (`timing`) VALUES
('1-0-0'),
('0-1-0'),
('0-0-1'),
('1-1-0'),
('1-0-1'),
('0-1-1'),
('1-1-1');

-- --------------------------------------------------------

--
-- Table structure for table `ward`
--

CREATE TABLE `ward` (
  `ward_name` varchar(20) NOT NULL,
  `ward_id` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ward`
--

INSERT INTO `ward` (`ward_name`, `ward_id`) VALUES
('Cardiology', '1'),
('General', '2');

-- --------------------------------------------------------

--
-- Table structure for table `ward_bed`
--

CREATE TABLE `ward_bed` (
  `ward_name` varchar(20) NOT NULL,
  `pat_contact_no` varchar(11) NOT NULL,
  `bed_no` varchar(5) NOT NULL,
  `bed_type` varchar(10) NOT NULL,
  `bed_cost` varchar(3) NOT NULL,
  `bed_status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ward_bed`
--

INSERT INTO `ward_bed` (`ward_name`, `pat_contact_no`, `bed_no`, `bed_type`, `bed_cost`, `bed_status`) VALUES
('Cardiology', '01679074498', '1', 'Normal', '300', 'Occupied'),
('Cardiology', '', '2', 'Normal', '300', 'Free'),
('Cardiology', '', '3', 'Normal', '300', 'Free'),
('Cardiology', '', '4', 'Normal', '300', 'Free'),
('Cardiology', '', '5', 'VIP', '700', 'Free'),
('General', '01679074498', '1', 'Normal', '200', 'Occupied'),
('General', '', '2', 'Normal', '200', 'Free'),
('General', '', '3', 'Normal', '200', 'Free'),
('General', '', '4', 'Normal', '200', 'Free'),
('General', '', '5', 'VIP', '700', 'Free');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`username`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `blood_group`
--
ALTER TABLE `blood_group`
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `medicine_name`
--
ALTER TABLE `medicine_name`
  ADD UNIQUE KEY `medicine_name` (`medicine_name`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`staff_id`);

--
-- Indexes for table `ward`
--
ALTER TABLE `ward`
  ADD UNIQUE KEY `ward_name` (`ward_name`),
  ADD UNIQUE KEY `ward_id` (`ward_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
