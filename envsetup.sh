export CWD_PATH=`pwd`
alias d-up='docker-compose -f $CWD_PATH/docker-compose-localhost.yml up -d'
alias d-down='docker-compose -f $CWD_PATH/docker-compose-localhost.yml down -v'
alias d-start='docker-compose -f $CWD_PATH/docker-compose-localhost.yml start'
alias d-stop='docker-compose -f $CWD_PATH/docker-compose-localhost.yml stop'
alias dps='docker ps -a'