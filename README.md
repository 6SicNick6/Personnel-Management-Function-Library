# 🧪 Personnel Management Function Library  

This project contains **unit tests** for the `qualitylibrary` C# library.  
The tests validate core functionality related to employees, password security, phone validation, and encryption.  

## 🚀 Features Tested  
- **Employee Management**  
  - `SetEmployee()` – assigns employee data (name, phones, birth date, hire date).  
  - `InfoEmployee()` – calculates employee age and experience.  
  - `LiveInAthens()` – counts employees based on Athens landline numbers.  

- **Validation**  
  - `ValidName()` – checks if a name exists in the employee list.  
  - `ValidPassword()` – enforces password rules (length, complexity).  
  - `CheckPhone()` – distinguishes between landline, mobile, and invalid numbers.  

- **Security**  
  - `EncryptPassword()` – encrypts passwords with a Caesar cipher-like method.  

## ⚙️ Requirements  
- **.NET 6.0 SDK** (or newer)  
- **MSTest** framework  

Install MSTest with NuGet if not included:  
```bash
dotnet add package MSTest.TestFramework
dotnet add package MSTest.TestAdapter
```

## ▶️ Running the Tests  
From the project root, run:  
```bash
dotnet test
```

This will execute all unit tests inside `Class1Tests.cs`.  

## 📊 Example Test Coverage  
- ✅ Valid and invalid employee creation  
- ✅ Name validation against employee list  
- ✅ Strong vs weak password validation  
- ✅ Password encryption with and without special characters  
- ✅ Phone number classification (landline, mobile, invalid)  
- ✅ Age and experience calculation  
- ✅ Athens-based employees detection  

## 📌 Notes  
- The tests are written with **MSTest**.  
- All assertions include **custom error messages** (in Greek) for debugging clarity.  
- Designed to ensure the **reliability and correctness** of the `qualitylibrary` functions.  
