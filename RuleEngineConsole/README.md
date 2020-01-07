##############        Rule Engine    ########################## 
Version :1.0
Date: 07/01/2020

Conceptual Approach:

For version 1.0
	- User must provide Rules.txt file, which will contain all the rules
	- Whenver the application runs 
		- it will fetch Rules text file 
		- it will also fetch the file for which the rule needs to be verified (raw_data.json)
	- Rules text file and raw_data file path must be mentioned in app.config file of the application.
	
	Design:
	
	A class that holds the rules data
	A class that holds the raw_data 
	Enums for Datatypes and Opeartors
	Interface for applying rule

	Based on the valuetype of the Rule model RuleFactory class generates the object of the RuleDatatype
	Ruledatatype then implements the applyRule method, which is written for every valuetype/Datatype.

	In future: if we want to expand/new requirement for any new value type  
	then below steps needs to be performed.
		- Create a class for that value type
		- Implement IRuleDataType interface in that class
		- override applyRule method of the interface for this new type.
		- In RuleTypeFactory class add a case for creating object of new value type class.

	If any new operator needs to be added then it must be added in the operator enum and then it needs to be
	imeplemented for a specific RuleDatatype class for which it is created.
	
	Rule text File Oprator must have values from "Operator" Enum only
	Rule text file ValueType values should be from "DataTypes" Enum only

	Please check Common----> Enums.cs file
	Same is applicable for raw_data.json's value_type 

	For Rule text File, the format f rule must follow the below given format:
	{"Name":"test","Signal":"ATL2","Value":"HIGH","ValueType":"String","Operator":"Equal"}
	Rule file must contain one rule per line.

	For raw_data - it should be a list of json strings, as shown below:
	[
	 {
		"signal": "ATL2",
		"value_type": "String",
		"value": "HIGH"
	  },
	  {
		"signal": "ATL9",
		"value_type": "Datetime",
		"value": "2017-06-13 22:40:10"
	  }
	]


	
What's the runtime performance? What is the complexity? Where are the bottlenecks?
- For any raw_data to get verified against the rules
	Worst case time complexity = O(maximum number of rules for 1 signal * number of raw_data)
	Amortized time complexity will be = O(n)  where n= number of data inputs. 

  Bottlenecks for current implementation would be 
   - it will not handle the json with different datatypes, which are not present in the problem definintion.   
    

If you had more time, what improvements would you make, and in what order of priority? 
- Would have provided UI through which user could enter the rule details which would be directly stored un rules.txt file.
- Would have seperated models and implementations.
- Would have created a generic rule engine, which could process all type of data (not only signal related data)
- Would have added exception handling with proper business logic