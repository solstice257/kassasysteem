FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Backend/Kassasysteem/User.Microservice/ ./
RUN dotnet restore "./User.Microservice/User.Microservice.csproj"
COPY Backend/Kassasysteem/User.Microservice.Test/ ./
RUN dotnet restore "./User.Microservice.Test/User.Microservice.Test.csproj"
COPY /Backend .
WORKDIR /src
RUN dotnet build "User.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.Microservice.dll"]


