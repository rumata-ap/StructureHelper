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

# Print unique strings
for s, attr_type in strings.items():
    print(f"{attr_type}: {s}")

print(f"\nTotal unique strings: {len(strings)}")
