cd front;
npm i;
ng build;
cd ../api;
cp ../front/dist/front/* ./wwwroot/ -r;
dotnet publish -c Release;
cd bin\Release\net6.0\publish;
dotnet api.dll