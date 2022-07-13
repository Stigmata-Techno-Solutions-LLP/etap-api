
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 

#
# copy csproj and restore as distinct layers
COPY *.sln ./
COPY ETapManagement.Api/*.csproj ./ETapManagement.Api/
COPY ETapManagement.Common/*.csproj ./ETapManagement.Common/
COPY ETapManagement.Domain/*.csproj ./ETapManagement.Domain/
COPY ETapManagement.Repository/*.csproj ./ETapManagement.Repository/
COPY ETapManagement.Service/*.csproj ./ETapManagement.Service/
COPY ETapManagement.ViewModel/*.csproj ./ETapManagement.ViewModel/
RUN dotnet restore 
#
# copy everything else and build app
# COPY ETapManagement.Api/. ./app/ETapManagement.Api/
# COPY ETapManagement.Common/. ./app/ETapManagement.Common/
# COPY ETapManagement.Domain/. ./app/ETapManagement.Domain/
# COPY ETapManagement.Repository/. ./app/ETapManagement.Repository/
# COPY ETapManagement.Service/. ./app/ETapManagement.Service/
# COPY ETapManagement.ViewModel/. ./app/ETapManagement.ViewModel/
# #

COPY . .
WORKDIR /app/ETapManagement.Api/
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

RUN mkdir -p /app/Documents
RUN mkdir -p /app/Images
COPY --from=build /app/ETapManagement.Api/out ./
# ENTRYPOINT ["dotnet", "ETapManagement.Api.dll"] for local run
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ETapManagement.Api.dll