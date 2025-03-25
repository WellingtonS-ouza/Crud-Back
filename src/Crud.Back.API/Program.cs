using Crud.Back.Application.AutoMapper;
using Crud.Back.Application.Interface;
using Crud.Back.Application.Services;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;
using Crud.Back.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CrudBackContext>(option =>
     option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
);

builder.Services.AddAutoMapper(typeof(DtoToEntityMappingProfile), typeof(EntityToDtoMappingProfile));

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IBandMemberRepository, BandMemberRepository>();
builder.Services.AddTransient<IBandRepository, BandRepository>();
builder.Services.AddTransient<IInstrumentRepository, InstrumentRepository>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IStyleRepository, StyleRepository>();

builder.Services.AddTransient<IBandService, BandService>();
builder.Services.AddTransient<IInstrumentService, InstrumentService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IStyleService, StyleService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
