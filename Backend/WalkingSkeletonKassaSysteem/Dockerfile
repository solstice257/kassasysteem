FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Backend/WalkingSkeletonKassaSysteem/*.csproj .
RUN dotnet restore "./WalkingSkeletonKassaSysteem.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WalkingSkeletonKassaSysteem.csproj" -c Release -o /app/build

# copy everything else and build app
COPY . .
WORKDIR /source/WalkingSkeletonKassaSysteem
RUN dotnet publish -c release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WalkingSkeletonKassaSysteem.dll"]


##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
##Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
##For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["WalkingSkeletonKassaSysteem.csproj", "."]
#RUN dotnet restore "./WalkingSkeletonKassaSysteem.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "WalkingSkeletonKassaSysteem.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "WalkingSkeletonKassaSysteem.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "WalkingSkeletonKassaSysteem.dll"]

# https://hub.docker.com/_/microsoft-dotnet
