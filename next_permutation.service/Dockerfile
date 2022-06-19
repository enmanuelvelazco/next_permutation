#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["next_permutation.service.csproj", "next_permutation.service/"]
RUN dotnet restore "next_permutation.service.csproj"
COPY . .
WORKDIR "/src/next_permutation.service"
RUN dotnet build "next_permutation.service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "next_permutation.service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "next_permutation.service.dll"]