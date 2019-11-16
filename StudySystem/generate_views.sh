#!/bin/bash

dotnet build

dotnet aspnet-codegenerator controller -name "$1Controller" -actions -m "$1" -dc SandboxDbContext -outDir Controllers

# dotnet aspnet-codegenerator controller -name CommunicationTypeController -actions -m CommunicationType -dc DataContext -outDir Controllers
# dotnet aspnet-codegenerator view Create Create -udl -outDir "Views/$1" -m "$1" --no-build
# dotnet aspnet-codegenerator view Edit Edit -udl -outDir "Views/$1" -m "$1" --no-build
# dotnet aspnet-codegenerator view Delete Delete -udl -outDir "Views/$1" -m "$1" --no-build
# dotnet aspnet-codegenerator view List List -udl -outDir "Views/$1" -m "$1" --no-build
# dotnet aspnet-codegenerator view Details Details -udl -outDir "Views/$1" -m "$1" --no-build
