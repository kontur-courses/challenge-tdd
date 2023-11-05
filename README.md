# Сhallenge TDD
[![.NET](https://github.com/kontur-courses/challenge-tdd/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kontur-courses/challenge-tdd/actions/workflows/dotnet.yml)

Задание по TDD в рамках темы eXtreme Programming

## Запуск тестов в терминале

На PostfixBuilder:  
```bash
dotnet test --filter FullyQualifiedName~PostfixBuilderTest --logger "console;verbosity=detailed"
```


На PostfixCalculator:  
```bash
dotnet test --filter FullyQualifiedName~PostfixCalculatorTest --logger "console;verbosity=detailed"
```
