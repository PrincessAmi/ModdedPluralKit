-- SCHEMA VERSION 6: 2020-03-??
create table groups
(
    id            serial primary key,
    system        serial                              not null references systems (id),
    hid           char(5) unique                      not null,
    name          text                                not null,
    description   text,
    avatar_url    text,
    tag           text,
    priority      int                                 not null default 0,
    group_privacy int check (group_privacy in (1, 2)) not null default 1,
    created       timestamp                           not null default (current_timestamp at time zone 'utc')
);

create table group_member
(
    group_id serial not null references groups (id),  -- "group_id" since "group" is a SQL keyword and I don't feel like quoting all the time
    member   serial not null references members (id)
);

update info
set schema_version = 6;