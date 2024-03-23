using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table user_role
    (
        id int primary key generated always as identity,
        role_name varchar(50) not null
    );

    create table users
    (
        id bigint primary key generated always as identity,
        username text not null,
        password varchar(20) not null,
        user_role_id int not null references user_role(id)
    );

    create table accounts
    (
        id bigint primary key generated always as identity,
        balance bigint not null,
        user_id bigint not null references users(id) 
    );

    create table history
    (
        id bigint primary key generated always as identity,
        account_id bigint not null references accounts(id),
        balance bigint not null
    )
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table accounts;
    drop table user_role;
    """;
}