FROM node:latest as node-sdk
WORKDIR /app
COPY ./front/package.json /
RUN npm install
COPY ./front/ /
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk AS dotnet-sdk
WORKDIR /app
COPY ./api/*.csproj ./
RUN dotnet restore
COPY ./api/ /
RUN dotnet publish -c Release -o build

FROM mcr.microsoft.com/dotnet/aspnet AS final
WORKDIR /app
COPY --from=dotnet-sdk /app/build .
COPY --from=node-sdk /app/dist/front ./wwwroot
#VOLUME 
ENTRYPOINT ["dotnet", "api.dll"]