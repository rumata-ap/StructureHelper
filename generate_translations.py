import re
import os
from collections import OrderedDict

# Find all XAML files
xaml_files = []
for root, dirs, files in os.walk('StructureHelper'):
    for file in files:
        if file.endswith('.xaml') and file not in ['Strings.en-US.xaml', 'Strings.ru-RU.xaml']:
            xaml_files.append(os.path.join(root, file))

strings = OrderedDict()

# Patterns to match
patterns = [
    (r'Content="([^"]+)"', 'Content'),
    (r'Header="([^"]+)"', 'Header'),
    (r'Text="([^"]+)"', 'Text'),
    (r'ToolTip="([^"]+)"', 'ToolTip'),
    (r'Title="([^"]+)"', 'Title'),
]

for xaml_file in xaml_files:
    with open(xaml_file, 'r', encoding='utf-8') as f:
        content = f.read()
    
    for pattern, attr_type in patterns:
        matches = re.findall(pattern, content)
        for match in matches:
            # Skip bindings and static resources
            if '{' in match or match.strip() == '':
                continue
            # Clean up the string
            clean_str = match.strip()
            if clean_str and clean_str not in strings:
                strings[clean_str] = attr_type

# Generate key names
def generate_key(text):
    # Remove special characters and spaces, keep only alphanumeric
    key = re.sub(r'[^a-zA-Z0-9]', '', text)
    # Capitalize first letter of each word
    words = re.findall(r'[A-Za-z][a-z]*|[A-Z]+(?=[A-Z]|$)', text)
    key = ''.join(word.capitalize() for word in words if word)
    # If key is empty, use hash
    if not key:
        key = f"Str_{abs(hash(text)) % 10000}"
    return key

# Generate translations dictionary
translations = {}
for text in strings.keys():
    key = generate_key(text)
    # Ensure unique keys
    base_key = key
    counter = 1
    while key in translations:
        key = f"{base_key}{counter}"
        counter += 1
    translations[key] = text

# Print as a table for translation
print("Key\tEnglish\tRussian")
print("=" * 80)
for key, text in translations.items():
    print(f"{key}\t{text}\t")

print(f"\nTotal unique strings: {len(translations)}")
