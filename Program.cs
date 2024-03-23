using DBService;
using Service;
using Structure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//-----------------------------------subscription-------------------------------------

builder.Services.AddScoped<AddSubscriptionService>();
builder.Services.AddScoped<AddSubscription>();
builder.Services.AddScoped<IAddSubscription,AddSubscription>();
builder.Services.AddScoped<GetSubscriptionService>();
builder.Services.AddScoped<GetSubscription>();
builder.Services.AddScoped<IGetSubscription,GetSubscription>();
builder.Services.AddScoped<UpdateSubscriptionService>();
builder.Services.AddScoped<UpdateSubscription>();
builder.Services.AddScoped<IUpdateSubscription,UpdateSubscription>();
builder.Services.AddScoped<DeleteSubscriptionService>();
builder.Services.AddScoped<DeleteSubscription>();
builder.Services.AddScoped<IDeleteSubscription,DeleteSubscription>();

//---------------------------------------component------------------

builder.Services.AddScoped<AddComponentService>();
builder.Services.AddScoped<AddComponent>();
builder.Services.AddScoped<IAddComponent,AddComponent>();
builder.Services.AddScoped<GetComponentService>();
builder.Services.AddScoped<GetComponent>();
builder.Services.AddScoped<IGetComponent,GetComponent>();
builder.Services.AddScoped<UpdateComponentService>();
builder.Services.AddScoped<UpdateComponent>();
builder.Services.AddScoped<IUpdateComponent,UpdateComponent>();
builder.Services.AddScoped<DeleteComponentService>();
builder.Services.AddScoped<DeleteComponent>();
builder.Services.AddScoped<IDeleteComponent,DeleteComponent>();

//----------------------------------- BUNDLE ----------------------------------------

builder.Services.AddScoped<BundleDBService>();
builder.Services.AddScoped<IBundleService,BundleDBService>();
builder.Services.AddScoped<BundleService>();

//----------------------------------- PRODUCT --------------------------------------

builder.Services.AddScoped<ProductDBService>();
builder.Services.AddScoped<IProductService, ProductDBService>();
builder.Services.AddScoped<ProductService>();
//------------------------------------Feature--------------------------------------
builder.Services.AddScoped<IFeatures,FeatureDBService>();
builder.Services.AddScoped<FeatureDBService>();
builder.Services.AddScoped<FeatureService>();
builder.Services.AddScoped<IAddInstitutionProduct,AddInstituteProductDb>();
builder.Services.AddScoped<AddInstituteProductDb>();
builder.Services.AddScoped<AddInstitutionProduct>();

//-------------------------------------- GET BUNDLE AND PRODUCT ------------------------

builder.Services.AddScoped<GetBundlesAndProductsDBService>();
builder.Services.AddScoped<GetBundleandProductService>();
builder.Services.AddScoped<IGetBundleandProduct, GetBundlesAndProductsDBService>();

//-----------------------------------group
builder.Services.AddScoped<GroupDB>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<IGroup,GroupDB>();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();