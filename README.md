Please use this command to generate the code coverage as this command excludes program.cs file that cannot be covered by test cases.

**Command : dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./TestResults/lcov.info /p:ExcludeByFile=**/program.cs**

**Coverage Report Image**
![Assignment4](https://github.com/varun-sharma01/dotNetAssignment_4/assets/143795512/d1db70f3-9a6c-4a45-a078-0e60aadced5c)
