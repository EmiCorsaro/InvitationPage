using InvitationPage;
using InvitationPageModel;
using InvitationPageModel.DataModels;
using InvitationPageModel.DataModels.Models.User;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationServices(builder.Configuration);
builder.Services.setDBContext();
builder.Services.AddInvitationModel();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.MapSwagger();
app.UseSwaggerUI();

app.Run();

