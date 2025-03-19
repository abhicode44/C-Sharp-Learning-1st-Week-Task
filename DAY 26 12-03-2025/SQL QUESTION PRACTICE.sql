CREATE TABLE DEPARTMENT (
	DEPT_ID INT PRIMARY KEY ,
	DEPT_NAME VARCHAR(20),
	LOCATION VARCHAR(20)
);

INSERT INTO DEPARTMENT(DEPT_ID, DEPT_NAME, LOCATION)
VALUES 
(10 , 'ACCOUNTING', 'NEW YORK '),
(20 , 'SELLS', ' DALLAS'),
(30 , 'RESEARCH', 'CHICAGO '),
(40 , 'OPERATIONS', ' BOSTON ')

CREATE TABLE EMPOLYEE (	
	EMP_ID INT PRIMARY KEY ,
	EMP_NAME VARCHAR(20) ,
	JOB_TITLE VARCHAR(20),
	COMMISION INT NOT NULL ,
	SALARY INT ,
	DEPT_ID INT ,
	FOREIGN KEY(DEPT_ID) REFERENCES DEPARTMENT(DEPT_ID) ,
	HIRE_DATE DATE,
	MANAGER_ID INT,
	FOREIGN KEY(MANAGER_ID) REFERENCES EMPOLYEE(EMP_ID),
);

INSERT INTO EMPOLYEE(
EMP_ID , EMP_NAME ,JOB_TITLE ,  COMMISION , SALARY ,DEPT_ID , HIRE_DATE , MANAGER_ID
)
VALUES 
(101 , 'SMITH' , 'CLERK' , NULL , 10000 , 10 , '2024-08-30' , 104 ),
(102 , 'AELLEN' , 'SALESMAN' , 1600 , 5000 , 10 , '2023-07-15' , 104),
(103 , 'BALAKE' , 'MANAGER' , 5000 , 45000 , 10 , '2022-06-03' , 104),
(104 , 'KING' , 'PRESIDENT' , NULL , 80000 , 10 , '2020-08-30' , NULL ),
(105 , 'ABHISHEK' , 'MANAGER' , 4000 , 50000 , 20 , '2022-06-18' , 104 ),
(106 , 'SCOTT' , 'ANALYAST' , NULL , 30000 , 20 , '2023-02-12' , 105 ),
(107 , 'ARITRA' , 'ANALYAST' , 2000 , 40000 , 30 , '2024-01-01' , 105 ),
(108 , 'PARITOSH' , 'SALESMAN' , 1800 , 35000 , 30 , '2024-03-08' , 103 ),
(109 , 'DEV' , 'CLERK' , NULL , 15000 , 20 , '2025-01-10' , 105 ),
(110 , 'SHUBHAM' , 'MANAGER' , 4000 , 45000 , 10 , '2020-08-10' , 104),
(111 , 'RAMESH' , 'MANAGER' , 2000 , 45000 , 10 , '2020-04-12' , 104);




SELECT * FROM EMPOLYEE ;

SELECT * FROM DEPARTMENT ;

--. Q.1 Display all employee names in ascending order
SELECT EMP_NAME FROM EMPOLYEE 
ORDER BY EMP_NAME ASC


--. Q.2  Display all employees(all columns) in department 20 and 30 
SELECT * FROM EMPOLYEE E
JOIN DEPARTMENT D
ON E.DEPT_ID = D.DEPT_ID
WHERE E.DEPT_ID=20 OR E.DEPT_ID=30 


--. Q.3 Display all the employees who are managers
SELECT EMP_NAME , JOB_TITLE
FROM EMPOLYEE 
WHERE JOB_TITLE='MANAGER' ;

--. Q.4  Display all the employees whose salary is between 2000 and 5000
SELECT EMP_NAME FROM EMPOLYEE WHERE SALARY BETWEEN 2000 AND 5000


-- Q.5 Display all the employees whose commission is null
SELECT EMP_NAME FROM EMPOLYEE WHERE COMMISION IS NULL 

-- Q.6 Display emp_name,salary,comission,ctc(calculated column)
SELECT EMP_NAME  , SALARY, COMMISION, 
(SALARY+ ISNULL(COMMISION, 0)*12) AS CTC
FROM EMPOLYEE 

-- Q.7. Display hire_date, current_date, tenure(calculated col) of the empl
SELECT EMP_NAME , HIRE_DATE, 
GETDATE() AS CURRENTDATE, 
DATEDIFF(YEAR, HIRE_DATE, 
GETDATE()) AS TENURE
FROM EMPOLYEE

-- Q.8. Display all the employees whose name starts with s
SELECT EMP_NAME 
FROM EMPOLYEE
WHERE EMP_NAME LIKE 'S%';


-- Q.9. Display unique department numbers from the employee table
SELECT DISTINCT DEPT_ID FROM EMPOLYEE;


-- Q.10 Display emp_name and job in lower case
SELECT LOWER(EMP_NAME) AS EMPOLYEE_NAME , 
LOWER(JOB_TITLE) AS JOB_ROLE FROM EMPOLYEE;

--#11 Select top 3 salary earning employee
SELECT TOP 3 EMP_NAME, SALARY
FROM EMPOLYEE
ORDER BY SALARY DESC ;

--#12 Select clerks and Managers in department 10
SELECT EMP_NAME, JOB_TITLE
FROM EMPOLYEE
WHERE (JOB_TITLE = 'CLERK' OR JOB_TITLE = 'MANAGER')
AND DEPT_ID = 10;

 -- Q.13 Display all clerks in asscending order of the department number 
 SELECT EMP_NAME , DEPT_ID FROM EMPOLYEE 
 WHERE JOB_TITLE='CLERK' 
 ORDER BY DEPT_ID ASC

-- Q.14 Display All employees in the same dept of 'SCOTT'
SELECT EMP_NAME , DEPT_ID FROM EMPOLYEE WHERE DEPT_ID =
(SELECT DEPT_ID FROM EMPOLYEE WHERE EMP_NAME = 'SCOTT');

-- Q.15  Employees having same designaƟon of SMITH 
SELECT EMP_NAME , JOB_TITLE
FROM EMPOLYEE 
WHERE JOB_TITLE = (SELECT JOB_TITLE FROM EMPOLYEE WHERE EMP_NAME = 'SMITH');

-- Q.16 Employee who are reproƟng under KING 
SELECT EMP_NAME , MANAGER_ID
FROM EMPOLYEE
WHERE MANAGER_ID = (SELECT EMP_ID FROM EMPOLYEE WHERE EMP_NAME = 'KING');


-- Q.17 Employees who have same salary of BLAKE 
SELECT EMP_NAME , SALARY
FROM EMPOLYEE 
WHERE SALARY = (SELECT SALARY FROM EMPOLYEE WHERE EMP_NAME = 'BALAKE');

-- Q.18  Display departmentwise number of employees 
SELECT DEPT_ID, COUNT(*) AS EMPLOYEE_COUNT
FROM EMPOLYEE
GROUP BY DEPT_ID;

-- Q.19 Display jobwise number of employees 
SELECT JOB_TITLE , COUNT(*) AS JOB_TITLE_COUNT
FROM EMPOLYEE
GROUP BY JOB_TITLE

-- Q.20 Display deptwise jobwise number of employees 
SELECT DEPT_ID, JOB_TITLE, COUNT(*) AS EMPLOYEE_COUNT
FROM EMPOLYEE
GROUP BY DEPT_ID, JOB_TITLE;

-- Q.21 Display deptwise employees greater than 3 
SELECT DEPT_ID, COUNT(*) AS EMPLOYEE_COUNT
FROM EMPOLYEE
GROUP BY DEPT_ID
HAVING COUNT(*) > 3;

-- Q.22 Display designation wise employees count greater than 3 
SELECT JOB_TITLE, COUNT(*) AS EMPLOYEE_COUNT
FROM EMPOLYEE
GROUP BY JOB_TITLE
HAVING COUNT(*) > 3;


-- Q.23  Display Employee name,deptname and location
SELECT E.EMP_NAME, D.DEPT_NAME, D.LOCATION
FROM EMPOLYEE E
JOIN DEPARTMENT D ON E.DEPT_ID = D.DEPT_ID;

-- Q.24  Display all deptnames and corresponding employees
SELECT D.DEPT_ID, E.EMP_NAME
FROM DEPARTMENT D
LEFT JOIN EMPOLYEE E ON D.DEPT_ID = E.DEPT_ID;

--Q.25. Dispay all deptnames where there are no employees SELECT D.DEPT_NAME
FROM DEPARTMENT D
LEFT JOIN EMPOLYEE E ON D.DEPT_ID = E.DEPT_ID
WHERE E.EMP_NAME IS NULL;

-- Q.26 Display deptname wise employee count greater than 3, display in descending order ofdeptname
SELECT D.DEPT_NAME, COUNT(E.EMP_ID) AS EMPLOYEE_COUNT
FROM DEPARTMENT D
LEFT JOIN EMPOLYEE E ON D.DEPT_ID = E.DEPT_ID
GROUP BY D.DEPT_NAME
HAVING COUNT(E.EMP_ID) > 3
ORDER BY D.DEPT_NAME DESC;

-- Q.27  Display all the empname and their manager names 
SELECT E.EMP_NAME AS Employee, M.EMP_NAME AS Manager
FROM EMPOLYEE  E
LEFT JOIN EMPOLYEE M ON E.MANAGER_ID = M.EMP_ID;

-- Q.28 . Display empname,deptname and manager name as bossname , order by bossname
SELECT 
    E.EMP_NAME AS Employee, 
    D.DEPT_NAME AS Department, 
    M.EMP_NAME AS BossName
FROM EMPOLYEE E
LEFT JOIN DEPARTMENT D ON E.DEPT_ID = D.DEPT_ID
LEFT JOIN EMPOLYEE M ON E.MANAGER_ID = M.EMP_ID
ORDER BY BossName;  

-- Q.29 Display Dname, employee name and names of their managers
SELECT 
    D.DEPT_NAME AS Department, 
    E.EMP_NAME AS Employee, 
    M.EMP_NAME AS Manager
FROM EMPOLYEE E
LEFT JOIN DEPARTMENT D ON E.DEPT_ID = D.DEPT_ID
LEFT JOIN EMPOLYEE M ON E.MANAGER_ID = M.EMP_ID;