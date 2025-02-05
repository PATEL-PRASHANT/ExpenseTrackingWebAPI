using ExpenseTrackingAPI.BRule.BusinessLayer.User.Private;
using ExpenseTrackingAPI.BRule.BusinessLayer.User;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Services.User;
using ExpenseTrackingAPI.Services.Bank;
using ExpenseTrackingAPI.BRule.BusinessLayer.Bank;
using ExpenseTrackingAPI.BRule.BusinessLayer.Bank.Private;
using ExpenseTrackingAPI.Services.BankBalance;
using ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance;
using ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance.Private;
using ExpenseTrackingAPI.BRule.BusinessLayer.CashBalace.Private;
using ExpenseTrackingAPI.BRule.BusinessLayer.CashBalace;
using ExpenseTrackingAPI.BRule.BusinessLayer.CashWithdrawlDetail.Private;
using ExpenseTrackingAPI.BRule.BusinessLayer.CashWithdrawlDetail;
using ExpenseTrackingAPI.BRule.BusinessLayer.Categorie.Private;
using ExpenseTrackingAPI.BRule.BusinessLayer.Categorie;
using ExpenseTrackingAPI.BRule.BusinessLayer.Expense.Private;
using ExpenseTrackingAPI.BRule.BusinessLayer.Expense;
using ExpenseTrackingAPI.BRule.BusinessLayer.PaymentType.Private;
using ExpenseTrackingAPI.BRule.BusinessLayer.PaymentType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

String connectionString = builder.Configuration.GetConnectionString("ExpenseTrackingDB")!;
builder.Services.AddTransient<IDataHelper, DataHelper>(conn =>
    new DataHelper(connectionString));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUser, User>();
builder.Services.AddTransient<IUserPrivate, UserPrivate>();

builder.Services.AddTransient<IBankService, BankService>();
builder.Services.AddTransient<IBank, Bank>();
builder.Services.AddTransient<IBankPrivate, BankPrivate>();

builder.Services.AddTransient<IBankBalanceService, BankBalanceService>();
builder.Services.AddTransient<IBankBalance, BankBalance>();
builder.Services.AddTransient<IBankBalancePrivate, BankBalancePrivate>();

builder.Services.AddTransient<ICashBalace, CashBalace>();
builder.Services.AddTransient<ICashBalacePrivate, CashBalacePrivate>();

builder.Services.AddTransient<ICashWithdrawlDetail, CashWithdrawlDetail>();
builder.Services.AddTransient<ICashWithdrawlDetailPrivate, CashWithdrawlDetailPrivate>();

builder.Services.AddTransient<ICategory, Category>();
builder.Services.AddTransient<ICategoryPrivate, CategoryPrivate>();

builder.Services.AddTransient<IExpenses, Expenses>();
builder.Services.AddTransient<IExpensesPrivate, ExpensesPrivate>();

builder.Services.AddTransient<IPaymentType, PaymentType>();
builder.Services.AddTransient<IPaymentTypePrivate, PaymentTypePrivate>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
