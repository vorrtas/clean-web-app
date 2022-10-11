cd front;
ng build;
cd ../api;
cp ../front/dist/front/* ./wwwroot/ -r;
dotnet publish -c Release;
cd ..;
dotnet api\bin\Release\net6.0\publish\api.dll