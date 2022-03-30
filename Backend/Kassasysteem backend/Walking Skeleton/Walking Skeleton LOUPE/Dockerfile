#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Walking Skeleton LOUPE/Walking Skeleton.csproj", "Walking Skeleton LOUPE/"]
RUN dotnet restore "Walking Skeleton LOUPE/Walking Skeleton.csproj"
COPY . .
WORKDIR "/src/Walking Skeleton LOUPE"
RUN dotnet build "Walking Skeleton.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Walking Skeleton.csproj" lease -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Walking Skeleton.dll"]