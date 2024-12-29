초기 설정  

# DB 생성

\SQLite\SQLite\DB\EF Core\SQLiteDbContext.cs에서  
OnConfiguring함수 안에 UseSqlite함수의 Connection String을   
ConnectionString.GetSqliteConnectionString()의 값으로 명시적으로 바꾼 후  
패키지 관리자 콘솔의 update-database 명령 실행  
(패키지 관리자 콘솔에서 ConnectionString.GetSqliteConnectionString()의 값이 다르게 들어가기 때문)