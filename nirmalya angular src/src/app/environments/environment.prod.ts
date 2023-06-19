export const environment = {
  production: false,
  // PATH: "http://192.168.0.102:4210/",
  //PATH: "https://medventory-backend.herokuapp.com/",
  // PATH: "https://med.kalyanimedical.com/",
  PATH: "https://api.darott.kishorevarma.net/",
  SESSION_ID: 'sessionId_',
  SESSION_PASS: 'sessionPass_'
};

export const PageList = [
{ name: "Upload", icon: "upload", list: [
    { name: "Movie Upload", url: "/movies", admin: 1 }
] }
];
