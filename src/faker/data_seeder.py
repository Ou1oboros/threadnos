from faker import Faker
from datetime import datetime
import psycopg2

fake = Faker()


db_params = {
    'host': 'localhost',       
    'port': 5432,              
    'database': 'threadnos',
    'user': 'postgres',
}

try:
    
    conn = psycopg2.connect(**db_params)
    cursor = conn.cursor()

    #base entity
    id = fake.uuid4()
    createdAt = datetime.now()
    updatedAt = datetime.now()
    isDeleted = False

    #unique to user
    name = fake.name()
    isActive = True
    lastLogin = datetime.now()


    insert_query = "INSERT INTO users (id, created_at, updated_at, is_deleted, name, is_active, last_login)" \
    "VALUES (%s, %s, %s, %s, %s, %s, %s)"
    cursor.execute(insert_query, (id, createdAt, updatedAt, isDeleted, name, isActive, lastLogin))

    conn.commit()

    print("Data inserted successfully!")

except Exception as e:
    print(f"Error: {e}")

finally:
    if cursor:
        cursor.close()
    if conn:
        conn.close()
