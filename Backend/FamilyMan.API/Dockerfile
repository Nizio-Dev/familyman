#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FamilyMan.API/FamilyMan.API.csproj", "FamilyMan.API/"]
COPY ["FamilyMan.Infrastructure/FamilyMan.Infrastructure.csproj", "FamilyMan.Infrastructure/"]
COPY ["FamilyMan.Application/FamilyMan.Application.csproj", "FamilyMan.Application/"]
COPY ["FamilyMan.Domain/FamilyMan.Domain.csproj", "FamilyMan.Domain/"]
RUN dotnet restore "FamilyMan.API/FamilyMan.API.csproj"
COPY . .
WORKDIR "/src/FamilyMan.API"
RUN dotnet build "FamilyMan.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamilyMan.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamilyMan.API.dll"]