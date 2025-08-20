from faker import Faker
from datetime import datetime
import psycopg2
import uuid

def base_entity():
    global id 
    global updatedAt 
    global createdAt 
    global isDeleted
    id = str(uuid.uuid4())
    updatedAt = fake.date_time(end_datetime = now)
    createdAt = fake.date_time(end_datetime = updatedAt)
    isDeleted = fake.boolean()
    
def seed_user():
    name = fake.user_name()
    isActive = fake.boolean()
    lastLogin = fake.date_time(end_datetime = now)

    insert_query = "INSERT INTO users (id, created_at, updated_at, is_deleted, name, is_active, last_login)" \
    "VALUES (%s, %s, %s, %s, %s, %s, %s)"
    cursor.execute(insert_query, (id, createdAt, updatedAt, isDeleted, name, isActive, lastLogin))
    
def seed_label():

    name = fake.word()
    insert_query = "INSERT INTO labels (id, created_at, updated_at, is_deleted, name)" \
    "VALUES (%s, %s, %s, %s, %s)"
    cursor.execute(insert_query, (id, createdAt, updatedAt, isDeleted, name))

def seed_page(order):
    title = fake.sentence(4, True)
    contentId = str(uuid.uuid4())
    content = fake.text()
    sortOrder = order
    insert_query = "INSERT INTO pages (id, created_at, updated_at, is_deleted, title, content_id, content, sort_order)" \
    "VALUES (%s, %s, %s, %s, %s, %s, %s, %s)"
    cursor.execute(insert_query, (id, createdAt, updatedAt, isDeleted, title, contentId, content, sortOrder))

def seed_threadline():
    name = fake.sentence(4, True)
    insert_query = "INSERT INTO threadline (id, created_at, updated_at, is_deleted, name)" \
    "VALUES (%s, %s, %s, %s, %s)"
    cursor.execute(insert_query, (id, createdAt, updatedAt, isDeleted, name))



fake = Faker()

now = datetime.now()

db_params = {
    'host': 'localhost',       
    'port': 5432,              
    'database': 'threadnos',
    'user': 'postgres',
}

try:
    
    conn = psycopg2.connect(**db_params)
    cursor = conn.cursor()

    for i in range(10):
        base_entity()
        seed_user()

    for i in range(10):
        base_entity()
        seed_label()

    for i in range(10):
        base_entity()
        seed_page(i)

    for i in range(10):
        base_entity()
        seed_threadline()


    conn.commit()

    print("Data inserted successfully!")

except Exception as e:
    print(f"Error: {e}")

finally:
    if cursor:
        cursor.close()
    if conn:
        conn.close()
