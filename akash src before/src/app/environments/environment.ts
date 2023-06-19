// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  // PATH: "http://192.168.0.102:4210/",
  //PATH: "https://medventory-backend.herokuapp.com/",
  // PATH: "https://med.kalyanimedical.com/",
  PATH: "https://localhost:7206",
};

export const pageList = [
{ name: "Upload", icon: "upload", list: [
    { name: "Movie Upload", url: "/movies", admin: 1 }
] }
];
