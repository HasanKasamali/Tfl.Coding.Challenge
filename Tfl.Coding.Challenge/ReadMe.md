# TFL Coding Challenge

## Steps to use from Visual Studio 2019
- Using Visual Studio 2019 Checkout the repository at https://github.com/HasanKasamali/Tfl.Coding.Challenge
- Restore Nuget Packages
- Clean and Rebuild the solution
- Register for a TFL api key at https://api-portal.tfl.gov.uk/
- Once you are registered at TFL, go to your profile in TFL and create a new product. This will also generate a new api key
- Go to config.json in the main Console application and replace the values there with those from your profile.
- Go to the Integration Tests replace the same above in the constructor for the Integration Tests.
- Using Test Explorer Run All Tests
## Running from command line

Rebuild the solution in Visual Studio 2019 using the Release profile

```sh
cd <repo folder>\Tfl.Coding.Challenge\bin\Release\netcoreapp3.1
tfl.coding.challenge.exe A10 -- road is found
tfl.coding.challenge.exe A6 -- road is not found
```

