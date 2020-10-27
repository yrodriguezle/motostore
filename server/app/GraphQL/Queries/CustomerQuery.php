<?php

namespace App\GraphQL\Queries;

use Illuminate\Support\Facades\DB;
use Illuminate\Database\Query\Builder;

class CustomerQuery
{
    /**
     * @param  null  $_
     * @param  array<string, mixed>  $args
     */
    public function __invoke($_, array $args)
    {
        // TODO implement the resolver
    }

    public function customers($root, array $args)
    {
        return DB::table('customers');
    }
}
