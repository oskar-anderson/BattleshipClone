import sys
import re
import getopt

from click import argument

def setLastCommitHashToIndexFile(argv):
    # constants
    ejs_pattern = "(<%=\s([a-zA-Z\-\_]+)\s%>)"
    template_file_path = './Battleship/BlazorApp/wwwroot/index-template.html'
    build_file_path = './Battleship/BlazorApp/wwwroot/index.html'
    
    # terminal argument handling
    arg_help = "{0} -h <help> <hash>".format(argv[0])
    if (len(argv) == 1):
        print("No arguments passed to script")
        sys.exit(2)
    commit_hash = ""
    try:
        opts, args = getopt.getopt(argv[1:], "h", ["help", "hash="])
        if (len(args) != 0):
            print(f"Unknown arguments passed {args}")
            sys.exit(2)
    except:
        print("Unknown command try: --help")
        sys.exit(2)
    for opt, arg in opts:
        if opt in ("-h", "--help"):
            print(arg_help)
            sys.exit(2)
        elif opt in ("--hash"):
            commit_hash = arg

    # function body
    template_file_content = ""    
    with open(template_file_path) as f:
        template_file_content = f.read()

    print("input string:", template_file_content)
    matches = re.findall(ejs_pattern, template_file_content)
    if (len(matches) == 0):
        print("No matches found!")
        sys.exit(2)
    for x in matches:
        key_in_templating_syntax = x[0]
        key = x[1]
        if (not key):
            raise RuntimeError("Match pattern does not have 2 groups: ", x)
        if (key == "commit-hash"):
            print(f"replacing: {key} with {commit_hash}")
            template_file_content = template_file_content.replace(key_in_templating_syntax, commit_hash)
    
    print("output string:", template_file_content)
    with open(build_file_path, 'w') as f:
        f.write(template_file_content)

  

setLastCommitHashToIndexFile(sys.argv)